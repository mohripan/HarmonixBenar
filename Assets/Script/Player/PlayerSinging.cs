using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PitchDetector;

public class PlayerSinging : MonoBehaviour
{
    public int maxMidi = 100;
    public int minMidi = 0;

    [SerializeField] private MicrophonePitchDetector pitchDetector;
    [SerializeField] private float dbThres = -40;
    private PlayerAnimation playerAnim;

    private Queue<PitchTime> drawQueue = new Queue<PitchTime>();

    internal float valPitch;

    private class PitchTime
    {
        public PitchTime(float pitch, float dt)
        {
            this.pitch = pitch;
            this.dt = dt;
        }
        public float pitch;
        public float dt;
    };

    private void Awake()
    {
        playerAnim = GetComponent<PlayerAnimation>();
    }

    private void Start()
    {
        pitchDetector.ToggleRecord();
        pitchDetector.onPitchDetected.AddListener(DrawPitch);
    }

    public void DrawPitch(List<float> pitchList, int samples, float db)
    {
        var duration = (float)samples / (float)pitchDetector.micSampleRate;
        var midis = RAPTPitchDetectorExtensions.HerzToMidi(pitchList);
        //Debug.Log("detected " + pitchList.Count + " values from " + samples + " samples, db:" + db);
        //Debug.Log(midis.NoteString());

        playerAnim.SetIsSinging(db > dbThres);

        if (pitchList.Count > 0 && db > dbThres)
        {
            foreach (var pitchVal in pitchList)
            {
                valPitch = pitchVal;
            }
        }
        else
        {
            valPitch = 0;
        }
    }
}
