using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FirstLight : MonoBehaviour
{
    public static FirstLight instance { get; private set; }
    public bool readyPlaying;

    [SerializeField] private float speed;
    private PlayerSinging playerSing;

    private Light2D light2d;

    private void Awake()
    {
        light2d = GetComponent<Light2D>();
        playerSing = GetComponentInParent<PlayerSinging>();
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (playerSing.valPitch > 0 && light2d.pointLightOuterRadius <= 7.8)
        {
            light2d.pointLightOuterRadius = light2d.pointLightOuterRadius + speed * Time.deltaTime;
        }

        else if(light2d.pointLightOuterRadius >= 7.8)
        {
            readyPlaying = true;
        }
    }
}
