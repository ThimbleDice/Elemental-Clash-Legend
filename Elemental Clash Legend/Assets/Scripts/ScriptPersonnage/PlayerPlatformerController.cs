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
            //playerAnim.Play("JumpingRight");
            animator.SetBool("Jump", true);
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        else if(grounded)
        {
           animator.SetBool("Jump", false);
        }
        else if (Input.GetButtonDown("Horizontal") && grounded)
        {
            playerAnim.Play("WalkingRight");
        }
        else if (Input.GetButtonDown("Fire1") && grounded)
        {
            playerAnim.Play("DeathRight");
        }
        else if (velocity.y < -1)
        {
            //animator.SetBool("Jump", false);
            print("cho");
        }

        animator.SetFloat("YVelocity", velocity.y);
        





        //bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (move.x == 0.00f)
        {

        }
        else if (move.x > 0.00f)
        {
            spriteRenderer.flipX = false;
        }
        else if (move.x < 0.00f)
        {
            spriteRenderer.flipX = true;
        }

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}