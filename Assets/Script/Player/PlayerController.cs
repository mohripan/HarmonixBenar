using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsObject))]
public class PlayerController : PhysicsObject
{
    public ParticleSystem dust;

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    internal Animator animator;

    private SpriteRenderer spriteRenderer;
    private bool valid;
    [SerializeField] private GameObject shadow;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void LandingSound()
    {
        if (grounded && !valid)
        {
            valid = true;
            GetComponentInChildren<PlayFootstepSounds>().PlayClip();
        }
    }

    protected override void ComputeVelocity()
    {
        shadow.SetActive(grounded);
        LandingSound();
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            valid = false;
            velocity.y = jumpTakeOffSpeed;
            CreateDust();
            GetComponentInChildren<PlayFootstepSounds>().PlayClip();
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(move.x != 0)
        {
            spriteRenderer.flipX = move.x < 0;
        }

        animator.SetBool("isGrounded", grounded);
        animator.SetFloat("moveX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = isOnSlope ? maxSpeed*slopeNormalPerpendicullar.x*-move : move*maxSpeed;
    }

    void CreateDust()
    {
        dust.Play();
    }
}
