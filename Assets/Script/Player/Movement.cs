using System;
using System.Collections.Specialized;
using UnityEngine;

public class Movement
{
    private float speed;
    private Vector3 prevVelocity;
    private Vector3 velocity;
    public Vector3 Velocity { get { return velocity; } set { velocity = value; } }
    private float maxJumpHeight;

    private float jumpForce;
    private float gravity;

    private float timeToJumpApex;

    private float velocityXSmoothing;
    private float targetVelocityX;

    private float accelerationTimeAirborne;
    private float accelerationTimeGrounded;

    private float gravityDown;
    private bool reachedApex = true;
    public bool ReachedApex { get { return reachedApex; } set { reachedApex = value; } }
    private float maxHeightReached = Mathf.NegativeInfinity;
    private float startHeight = Mathf.NegativeInfinity;

    private float deltaTime = 0;
    public float DeltaTime { get { return deltaTime; } set { value = deltaTime; } }

    public Movement(float speed, float maxJumpHeight, float timeToJumpApex, float accelerationTimeAirborne, float accelerationTimeGrounded)
    {
        this.speed = speed;
        this.maxJumpHeight = maxJumpHeight;
        this.timeToJumpApex = timeToJumpApex;
        this.accelerationTimeAirborne = accelerationTimeAirborne;
        this.accelerationTimeGrounded = accelerationTimeGrounded;

        gravity = -2 * maxJumpHeight / Mathf.Pow(timeToJumpApex, 2);
        gravityDown = gravity * 2;

        jumpForce = 2 * maxJumpHeight / timeToJumpApex;
    }

    public void CalculateUpdate(float h, float y)
    {
        if (!reachedApex && maxHeightReached > y)
        {
            float delta = maxHeightReached - startHeight;
            float error = maxJumpHeight - delta;


            reachedApex = true;
            gravity = gravityDown;
        }
        maxHeightReached = Mathf.Max(y, maxHeightReached);

        targetVelocityX = h * speed;
    }

    public Vector3 CalculateDeltaPosition(float acceleration, float fixedDeltaTime)
    {
        prevVelocity = velocity;

        velocity.x = Mathf.SmoothDamp(
            velocity.x,
            targetVelocityX,
            ref velocityXSmoothing,
            acceleration);
        velocity.y += gravity * fixedDeltaTime;
        Vector3 deltaPosition = (prevVelocity + velocity) * 0.5f * fixedDeltaTime;
        return deltaPosition;
    }

    public void DoubleGravity()
    {
        gravity = gravityDown;
    }

    public void ZeroVelocityY()
    {
        velocity.y = 0;
    }

    public void Jump(float startHeight)
    {
        deltaTime = 0;
        velocity.y = jumpForce;

        gravity = -2 * maxJumpHeight / Mathf.Pow(timeToJumpApex, 2);
        reachedApex = false;
        maxHeightReached = Mathf.NegativeInfinity;
        this.startHeight = startHeight;
    }
}
