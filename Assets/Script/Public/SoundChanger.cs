using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChanger : MonoBehaviour
{
    [SerializeField] internal bool changeVolume;
    private bool beginChange;
    [SerializeField] private bool onlyStay;

    [SerializeField] private float toZero;
    [SerializeField] private float timer;
    private void Start()
    {
        if (changeVolume && AudioManager.instance != null)
        {
            AudioManager.instance.SetVolume(1);
        }
    }

    private void Update()
    {
        Classifier();
    }

    private void CalculateTimer()
    {
        timer = timer - 1 * Time.deltaTime;

        if(timer <= 0)
        {
            beginChange = true;
        }
    }

    private void Classifier()
    {
        if (onlyStay)
        {
            CalculateTimer();
        }

        if (beginChange)
        {
            float volume = AudioManager.instance.GetVolume();
            volume = volume - toZero * Time.deltaTime;
            AudioManager.instance.SetVolume(volume);
        }
    }

    public void ChangeByClickButton()
    {
        beginChange = true;
    }
}
