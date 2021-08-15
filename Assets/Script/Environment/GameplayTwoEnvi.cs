using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayTwoEnvi : MonoBehaviour
{
    private bool valid;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            valid = true;
            anim.SetBool("isIn", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            valid = false;
            anim.SetBool("isIn", false);
        }
    }

    private void Update()
    {
        Physics2D.SyncTransforms();

    }
}
