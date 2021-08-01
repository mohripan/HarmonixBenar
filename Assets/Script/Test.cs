using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private PlayerSinging playerSinging;

    private bool valid;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            valid = true;
        }
    }

    private void Update()
    {
        if (valid)
        {
            anim.SetBool("isSinging", playerSinging.valPitch > 200);
        }
    }
}
