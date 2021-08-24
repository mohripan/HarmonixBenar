using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTest : MonoBehaviour
{
    [SerializeField] private float DelayGerbang;
    private float hitung;
    [SerializeField] private Animator anime;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "sesuatu")
        {
            Debug.Log(hitung);
            hitung += 1 * Time.deltaTime;
            if(hitung >= DelayGerbang)
            {
                anime.SetBool("isDone", true);
            }
        }
    }

    void Update()
    {
        
    }
}
