using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MicrophoneInputs : MonoBehaviour
{
    private bool micConnected = false;

    private int minFreq;
    private int maxFreq;
 
    private AudioSource goAudioSource;

    public AudioMixerGroup mixerGroupMicrophone, mixerGroupMaster;

    private void Awake()
    {
        goAudioSource = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        if (Microphone.devices.Length < 0)
        {
            Debug.Log("Tidak ada");  
            goAudioSource.outputAudioMixerGroup = mixerGroupMaster; 
        }
        else 
        {
            goAudioSource.outputAudioMixerGroup = mixerGroupMicrophone; 
            micConnected = true;

            Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);
  
            if (minFreq == 0 && maxFreq == 0)
            {
                maxFreq = 44100;
            }

            goAudioSource.clip = Microphone.Start(null, true, 10, maxFreq);
            goAudioSource.Play();
        }
    }

    private void Update()
    {
        if (micConnected)
        {

        }
    }

    //void OnGUI()
    //{
    //    //If there is a microphone  
    //    if (micConnected)
    //    {
    //        //If the audio from any microphone isn't being captured  
    //        if (!Microphone.IsRecording(null))
    //        {
    //            //Case the 'Record' button gets pressed  
    //            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Record"))
    //            {
    //                //Start recording and store the audio captured from the microphone at the AudioClip in the AudioSource  
    //                goAudioSource.clip = Microphone.Start(null, true, 20, maxFreq);
    //            }
    //        }
    //        else //Recording is in progress  
    //        {
    //            //Case the 'Stop and Play' button gets pressed  
    //            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Stop and Play!"))
    //            {
    //                Microphone.End(null); //Stop the audio recording  
    //                goAudioSource.Play(); //Playback the recorded audio  
    //            }

    //            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 200, 50), "Recording in progress...");
    //        }
    //    }
    //    else // No microphone  
    //    {
    //        //Print a red "Microphone not connected!" message at the center of the screen  
    //        GUI.contentColor = Color.red;
    //        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Microphone not connected!");
    //    }

    //}
}
