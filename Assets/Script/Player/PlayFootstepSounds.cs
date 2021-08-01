using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstepSounds : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<AudioSource>().Play();
    }
}
