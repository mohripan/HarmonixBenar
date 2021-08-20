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
            valid = true;
            anim.SetBool("isIn", true);
            cinemachineAnim.SetBool("isIn", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            valid = false;
            anim.SetBool("isIn", false);
            cinemachineAnim.SetBool("isIn", false);
        }
    }

    private void Update()
    {
        if (valid)
        {

        }
    }
}
