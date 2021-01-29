using UnityEngine;

namespace AGDDPlatformer
{
    public class PlayerController : KinematicObject
    {
        [Header("Movement")]
        public float maxSpeed = 7;
        public float jumpSpeed = 7;
        public float jumpDeceleration = 0.5f; // Upwards slow after releasing jump button
        public float cayoteTime = 0.1f; // Lets player jump just after leaving ground
        public float jumpBufferTime = 0.1f; // Lets the player input a jump just before becoming grounded

        [Header("Audio")]
        public AudioSource source;
        public AudioClip jumpSound;

        Vector2 startPosition;
        bool startOrientation;

        float lastJumpTime;
        float lastGroundedTime;
        bool canJump;
        bool jumpReleased;
        Vector2 move;

        SpriteRenderer spriteRenderer;

        void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            lastJumpTime = -jumpBufferTime * 2;

            startPosition = transform.position;
            startOrientation = spriteRenderer.flipX;
        }

        void Update()
        {
            isFrozen = GameManager.instance.timeStopped;

            /* --- Read Input --- */

            move.x = Input.GetAxisRaw("Horizontal");
            if (gravityModifier < 0)
            {
                move.x *= -1;
            }

            if (Input.GetButtonDown("Jump"))
            {
                // Store jump time so that we can buffer the input
                lastJumpTime = Time.time;
            }

            if (Input.GetButtonUp("Jump"))
            {
                jumpReleased = true;
            }

            /* --- Compute Velocity --- */

            // Store grounded time to allow for late jumps
            if (isGrounded)
            {
                lastGroundedTime = Time.time;
                canJump = true;
            }

            // Allow for buffered jumps and late jumps
            float timeSinceJumpInput = Time.time - lastJumpTime;
            float timeSinceLastGrounded = Time.time - lastGroundedTime;

            if (canJump && timeSinceJumpInput <= jumpBufferTime && timeSinceLastGrounded <= cayoteTime)
            {
                velocity.y = Mathf.Sign(gravityModifier) * jumpSpeed;
                canJump = false;
                isGrounded = false;

                source.PlayOneShot(jumpSound);
            }
            else if (jumpReleased)
            {
                // Decelerate upwards velocity when jump button is released
                if ((gravityModifier >= 0 && velocity.y > 0) ||
                    (gravityModifier < 0 && velocity.y < 0))
                {
                    velocity.y *= jumpDeceleration;
                }
                jumpReleased = false;
            }

            velocity.x = move.x * maxSpeed;

            /* --- Adjust Sprite --- */

            // Assume the sprite is facing right, flip it if moving left
            if (move.x > 0.01f)
            {
                spriteRenderer.flipX = false;
            }
            else if (move.x < -0.01f)
            {
                spriteRenderer.flipX = true;
            }
        }

        public void ResetPlayer()
        {
            transform.position = startPosition;
            spriteRenderer.flipX = startOrientation;

            lastJumpTime = -jumpBufferTime * 2;

            velocity = Vector2.zero;
        }
    }
}
