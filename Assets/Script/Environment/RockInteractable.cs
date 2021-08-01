using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInteractable : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject interactW;

    private void Awake()
    {
        if(interactW != null)
            interactW.transform.localScale = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckPlayer(collision, true, new Vector3(1, 1, 1));
    }

    private void CheckPlayer(Collider2D collision, bool valid, Vector3 sizing)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("isIn", valid);
            if(interactW != null)
                interactW.transform.localScale = sizing;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckPlayer(collision, false, new Vector3(0,0,0));
    }
}
