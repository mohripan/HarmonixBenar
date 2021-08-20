using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTwoDraw : MonoBehaviour
{
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


}
