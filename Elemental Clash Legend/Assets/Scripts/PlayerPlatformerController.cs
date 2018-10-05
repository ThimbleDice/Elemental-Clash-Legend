using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 100;
    public float jumpTakeOffSpeed = 7;
    [SerializeField] Animator playerAnim;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            playerAnim.Play("JumpingRight");
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        //bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (move.x == 0.00f)
        {

        }
        else if (move.x > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (move.x < 0.01f)
        {
            spriteRenderer.flipX = true;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}