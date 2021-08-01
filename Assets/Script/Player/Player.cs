using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour
{
    // Inspector Variables
    [SerializeField] private float moveSpeed = 6f; // 6f
    public float MoveSpeed { get { return moveSpeed; } }
    // Assign values to these to determine gravity and jumpVelocity
    [SerializeField] private float maxJumpHeight = 4f; // 4f
    [SerializeField] private float timeToJumpApex = 0.4f; // 0.4f
    // X Velocity Smoothing Variables
    [SerializeField] private float accelerationTimeAirborne = 0.2f; // 0.2f
    [SerializeField] private float accelerationTimeGrounded = 0.1f; // 0.1f



    //[SerializeField] private Text gravityText = null;
    //[SerializeField] private Text jumpVelocityText = null;

    // Start Variables
    public Controller2D controller;
    public Movement movement;

    // Interfaces
    public IUnityService UnityService;

    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public static Player CreatePlayer(GameObject playerObj, Controller2D controller)
    {
        Player player = playerObj.AddComponent<Player>();
        player.controller = controller;
        return player;
    }
    private void Start()
    {
        controller = GetComponent<Controller2D>();
        movement = new Movement(
            moveSpeed, 
            maxJumpHeight, 
            timeToJumpApex,
            accelerationTimeAirborne,
            accelerationTimeGrounded
            );

        if (UnityService == null)
            UnityService = new UnityService();
    }

    private void Update()
    {
        if (UnityService.GetKeyUp(KeyCode.Space))
        {
            movement.DoubleGravity();
        }

        if (UnityService.GetKeyDown(KeyCode.Space) && controller.Collisions.below)
        {
            movement.Jump(transform.position.y);
        }

        movement.CalculateUpdate(
                UnityService.GetAxisRaw("Horizontal"),
                transform.position.y);

    }
    void FixedUpdate()
    {
        FlipSprite();

        if (!controller.Collisions.below && !movement.ReachedApex)
        {
            movement.DeltaTime += UnityService.GetFixedDeltaTime();
        }

        controller.Move(
            movement.CalculateDeltaPosition(
                    (controller.Collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne,
                    UnityService.GetFixedDeltaTime()
                )
            );

        if (controller.Collisions.above || controller.Collisions.below)
        {
            movement.ZeroVelocityY();
        }

        //// Removes the continuous collision force left/right
        //if (controller.Collisions.left || controller.Collisions.right)
        //{
        //    velocity.x = 0;
        //}
    }

    private void FlipSprite()
    {
        float motion = UnityService.GetAxisRaw("Horizontal");

        if (motion != 0)
        {
            spriteRenderer.flipX = motion < 0;
        }
    }
}
