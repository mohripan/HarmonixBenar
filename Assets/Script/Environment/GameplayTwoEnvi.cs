using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameplayTwoEnvi : MonoBehaviour
{
    public static GameplayTwoEnvi instance { get; private set; }
    internal bool valid;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator cinemachineAnim;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Extraction(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Extraction(false);
        }
    }

    private void Extraction(bool validasi)
    {
        valid = validasi;
        anim.SetBool("isIn", validasi);
        cinemachineAnim.SetBool("isIn", validasi);
    }

    private void Update()
    {
        if (!GameTwoDraw.instance.enter)
        {
            Extraction(false);
        }
    }
}
