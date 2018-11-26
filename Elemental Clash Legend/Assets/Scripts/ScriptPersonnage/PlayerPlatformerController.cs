using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public bool playerTurn = false;
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

        if (playerTurn){
            move.x = Input.GetAxis("Horizontal");
            PlayerInput();
        }
        if (grounded)
            GetGrounded();


        animator.SetFloat("YVelocity", velocity.y);
        animator.SetFloat("XVelocity", velocity.x);
        

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
        animator.SetFloat("XVelocity", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    public void PlayerInput()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            StartJump();
        }
        else if (Input.GetButtonUp("Jump"))
        {
            DecreaseJumpVelocity();
        }
        else if (Input.GetButtonDown("Horizontal") && grounded)
        {
            HorizontalMouvement(Input.GetAxis("Horizontal"));
        }
        else if (Input.GetKeyDown(KeyCode.O) && grounded)
        {
            Die();
        }
        else if (Input.GetKeyDown(KeyCode.L) && grounded)
        {
            TakeDamage();
        }
    }

    public void StartJump()
    {
        animator.SetBool("Jump", true);
        velocity.y = jumpTakeOffSpeed;
        AudioForCharacter.JumpSound();
    }

    public void DecreaseJumpVelocity()
    {
        if (velocity.y > 0)
            velocity.y = velocity.y * 0.5f;
    }

    public void GetGrounded()
    {
        animator.SetBool("Jump", false);
    }

    public void HorizontalMouvement(float speed)
    {
        velocity.x = speed;
    }

    public void Die()
    {
        animator.SetBool("Death", true);
        AudioForCharacter.DeathSound();
    }

    public void TakeDamage()
    {
        animator.SetTrigger("TakingDamage");
        AudioForCharacter.TakingDamageSound();
    }

}