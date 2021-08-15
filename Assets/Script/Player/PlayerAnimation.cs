using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private bool isGrounded;
    private bool isSinging;
    private float moveX;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isSinging", isSinging);
        anim.SetFloat("moveX", moveX);
    }

    public bool GetIsGrounded() => this.isGrounded;
    public bool GetIsSinging() => this.isSinging;
    public float GetMoveX() => this.moveX;

    public void SetIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }

    public void SetIsSinging(bool isSinging)
    {
        this.isSinging = isSinging;
    }

    public void SetMoveX(float moveX)
    {
        this.moveX = moveX;
    }
}
