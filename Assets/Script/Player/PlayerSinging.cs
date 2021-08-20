using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PitchDetector;

public class PlayerSinging : MonoBehaviour
{
    public int maxMidi = 100;
    public int minMidi = 0;

    public GameObject noteIndicatorPrefab;

    [SerializeField] private MicrophonePitchDetector pitchDetector;
    [SerializeField] private float dbThres = -40;
    private PlayerAnimation playerAnim;

    //private Queue<PitchTime> drawQueue = new Queue<PitchTime>();

    //private float scrollSpeed = 1f;
    //private float appTime = 0f;
    //private float analysisTime = 0f;
    //private const float secsPerScreen = 10f;

    internal float valPitch;

    //private class PitchTime
    //{
    //    public PitchTime(float pitch, float dt)
    //    {
    //        this.pitch = pitch;
    //        this.dt = dt;
    //    }
    //    public float pitch;
    //    public float dt;
    //};

    private void Awake()
    {
        playerAnim = GetComponent<PlayerAnimation>();
    }

    private void Start()
    {
        pitchDetector.ToggleRecord();
        pitchDetector.onPitchDetected.AddListener(DrawPitch);

        //AutoDestroy.Lifetime = 0.5f * secsPerScreen;
    }

    private void Update()
    {
        //if (GameplayTwoEnvi.instance.valid)
        //{
            
        //}

        //appTime += Time.deltaTime;
        //while (analysisTime < appTime && drawQueue.Count > 0)
        //{
        //    var item = drawQueue.Dequeue();
        //    var midi = RAPTPitchDetectorExtensions.HerzToFloatMidi(item.pitch);
        //    if (!float.IsInfinity(midi))
        //    {
        //        float y = MidiToScreenY(midi);
        //        float x = analysisTime * scrollSpeed;
        //        GameObject newNote = Instantiate<GameObject>(noteIndicatorPrefab);
        //        newNote.transform.position = new Vector3(x, y*10);
        //        newNote.transform.SetParent(transform, false);
        //    }
        //    analysisTime += item.dt;
        //}

        //MoveLeft(scrollSpeed * Time.deltaTime);
    }

    public void DrawPitch(List<float> pitchList, int samples, float db)
    {
        var duration = (float)samples / (float)pitchDetector.micSampleRate;
        var midis = RAPTPitchDetectorExtensions.HerzToMidi(pitchList);

        playerAnim.SetIsSinging(db > dbThres);

        if (pitchList.Count > 0 && db > dbThres)
        {
            foreach (var pitchVal in pitchList)
            {
                //drawQueue.Enqueue(new PitchTime(pitchVal, duration / pitchList.Count));
                valPitch = pitchVal;
            }
        }

        //else if (pitchList.Count > 0 && db > dbThres && GameplayTwoEnvi.instance.valid)
        //{
        //    foreach (var pitchVal in pitchList)
        //    {
                
        //    }
        //}

        else
        {
            //drawQueue.Enqueue(new PitchTime(0f, duration));
            valPitch = 0;
        }
    }

    //private float MidiToScreenY(float midiVal)
    //{
    //    if (float.IsInfinity(midiVal))
    //    {
    //        midiVal = RAPTPitchDetectorExtensions.HerzToMidi(1f);
    //    }
    //    float viewHeight = 2 * Camera.main.orthographicSize;
    //    float dy = viewHeight / (float)(maxMidi - minMidi);
    //    float middleMidi = 0.5f * (float)(maxMidi + minMidi);
    //    return dy * (midiVal - middleMidi);

    //}

    //private void MoveLeft(float amount)
    //{
    //    var tmp = transform.position;
    //    tmp.x -= amount;
    //    transform.position = tmp;
    //}
}
