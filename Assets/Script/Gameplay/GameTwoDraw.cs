using PitchDetector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTwoDraw : MonoBehaviour
{
    public int maxMidi = 100;
    public int minMidi = 0;

    public static GameTwoDraw instance { get; private set; }
    private class PitchTime
    {
        public PitchTime(float pitch, float dt)
        {
            this.pitch = pitch;
            this.dt = dt;
        }
        public float pitch;
        public float dt;
    }

    private Queue<PitchTime> drawQueue = new Queue<PitchTime>();

    [SerializeField] private float speed;
    [SerializeField] private float secsPerScreen;
    [SerializeField] private PlayerSinging playerSinging;
    [SerializeField] private float maxY;

    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float indicatorY;

    [SerializeField] private GameObject indicatorPrefab;
    [SerializeField] private Transform followTransform;

    private float apptime = 0f;
    private float analysisTime = 0f;

    private bool enter = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetEnter(true, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SetEnter(false, collision);
    }

    private void SetEnter(bool entering, Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            enter = entering;
        }
    }

    private void Update()
    {
        if (enter && playerSinging.valPitch > 0)
        {
            apptime += Time.deltaTime;

            while (analysisTime < apptime && drawQueue.Count > 0)
            {
                var item = drawQueue.Dequeue();
                var midi = RAPTPitchDetectorExtensions.HerzToFloatMidi(item.pitch);
                if (!float.IsInfinity(midi))
                {
                    float y = MidiToScreenY(midi);
                    float x = analysisTime * speed;
                    GameObject newNote = Instantiate<GameObject>(indicatorPrefab);
                    newNote.transform.position = new Vector3(x+offsetX, y * indicatorY+offsetY);
                    newNote.transform.SetParent(transform, false);
                }
                analysisTime += item.dt;
            }

            MoveRight(speed * Time.deltaTime);
        }
    }

    public void DrawQueue(float pitchVal, float duration, List<float> pitchList, bool valid)
    {
        if (enter)
        {
            if (valid)
                drawQueue.Enqueue(new PitchTime(pitchVal, duration / pitchList.Count));
            else
                drawQueue.Enqueue(new PitchTime(0f, duration));
        }
    }

    private float MidiToScreenY(float midiVal)
    {
        if (float.IsInfinity(midiVal))
        {
            midiVal = RAPTPitchDetectorExtensions.HerzToMidi(1f);
        }

        float viewHeight = 2 * Camera.main.orthographicSize;
        float dy = viewHeight / (float)(maxMidi - minMidi);
        float middleMidi = 0.5f * (float)(maxMidi + minMidi);
        return Mathf.Min(dy * (midiVal - middleMidi), maxY);

    }

    private void MoveRight(float amount)
    {
        var tmp = followTransform.position;
        tmp.x += amount;
        followTransform.position = tmp;
    }
}
