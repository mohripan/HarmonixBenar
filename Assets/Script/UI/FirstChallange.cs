using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstChallange : MonoBehaviour
{
    [SerializeField] private GameObject singOrHumming;
    [SerializeField] private PlayerSinging playerSinging;

    private bool oneTime;
    private bool valid;

    private void SingHum(bool validasi)
    {
        if (singOrHumming != null)
            singOrHumming.SetActive(validasi);
    }

    private void Start()
    {
        SingHum(false);
    }

    private void Update()
    {
        if (valid)
        {
            if (playerSinging.valPitch > 0)
            {
                oneTime = true;
                singOrHumming.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SingHum(!oneTime);
            valid = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            valid = false;
        }
    }
}
