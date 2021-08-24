using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDrop : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            anim.SetBool("isIn", true);
        }
    }
}
