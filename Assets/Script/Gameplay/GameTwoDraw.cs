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
    [SerializeField] private float speedX;
    [SerializeField] private float secsPerScreen;
    [SerializeField] private float currentYFollow;
    [SerializeField] private float multiplying;
    [SerializeField] private PlayerSinging playerSinging;
    [SerializeField] private float maxY;

    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float indicatorY;

    [SerializeField] private GameObject indicatorPrefab;
    [SerializeField] private Transform followTransform;

    [SerializeField] private Vector2 normalisasi;

    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem particle;

    public GameObject currentLine;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPosition;

    private bool firstSing;

    internal bool enter = false;
    private bool validasi;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {

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
            if (!firstSing)
            {
                CreateLine();
                firstSing = true;
            }

            if(followTransform.localPosition.x >= 15.8f)
            {
                enter = false;
                anim.SetBool("isIn", true);
                particle.Play();
            }

            Vector2 tempFingerPos = followTransform.position;
            if(Vector2.Distance(tempFingerPos, fingerPosition[fingerPosition.Count - 1]) > .1f)
            {
                UpdateLine(tempFingerPos);
            }

            //apptime += Time.deltaTime;

            //while (analysisTime < apptime && drawQueue.Count > 0)
            //{
            //    var item = drawQueue.Dequeue();
            //    var midi = RAPTPitchDetectorExtensions.HerzToFloatMidi(item.pitch);
            //    if (!float.IsInfinity(midi))
            //    {
            //        float y = MidiToScreenY(midi);
            //        float x = analysisTime * speed;
            //        GameObject newNote = Instantiate<GameObject>(indicatorPrefab);
            //        newNote.transform.position = new Vector3(x+offsetX, y * indicatorY+offsetY);
            //        newNote.transform.SetParent(transform, false);
            //    }
            //    analysisTime += item.dt;
            //}

            MoveRight(speed, playerSinging.valPitch);
        }
        else
        {
            firstSing = false;
        }
    }

    private void CreateLine()
    {
        currentLine = Instantiate(indicatorPrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();

        //currentLine.transform.SetParent(followTransform);

        fingerPosition.Clear();
        fingerPosition.Add(new Vector2(followTransform.position.x, followTransform.position.y));
        fingerPosition.Add(new Vector2(followTransform.position.x, followTransform.position.y));

        lineRenderer.SetPosition(0, fingerPosition[0]);
        lineRenderer.SetPosition(1, fingerPosition[1]);

        edgeCollider.points = fingerPosition.ToArray();
    }

    private void UpdateLine(Vector2 newFingerPosition)
    {
        fingerPosition.Add(newFingerPosition);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1, newFingerPosition);
        edgeCollider.points = fingerPosition.ToArray();
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

    private void MoveRight(float amount, float pitching)
    {
        var tmp = followTransform.position;
        tmp.x += speedX*Time.deltaTime;
        normalisasi.x = tmp.x;
        tmp.y = Mathf.Min(Mathf.SmoothStep(tmp.y, Mathf.Max(12, currentYFollow + (pitching/35) * multiplying), 100f), maxY);
        
        if (!validasi)
        {
            normalisasi.y = tmp.y;
            validasi = true;
        }

        //Debug.Log(currentYFollow + (pitching / 35)*multiplying);
        followTransform.position = Vector2.Lerp(followTransform.position, tmp, amount*Time.deltaTime);
    }
}
