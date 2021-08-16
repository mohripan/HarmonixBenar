using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPlayer : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        bool valid = anim.GetBool("isGrounded");
        spriteRenderer.color = valid ? new Color32(255, 255, 255, 255) : new Color32(255, 255, 255, 0);
    }
}
