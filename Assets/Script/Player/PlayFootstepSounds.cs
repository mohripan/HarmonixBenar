using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstepSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private void OnEnable()
    {
        GetComponent<AudioSource>().Play();
    }

    public void PlayClip()
    {
        GetComponent<AudioSource>().Play();
    }
}
