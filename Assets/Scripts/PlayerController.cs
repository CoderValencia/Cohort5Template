using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Mover mover;
    public Jumper jumper;
    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    private Animator animator;

    private void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame, around 60 times a second
    void Update()
    {
        //Animator script is from level 2! If we have an animator... 
        if (animator != null)
        {
            //Tell the animator that we are not currently walking 
            animator.SetBool("Walking", false);
            //Tell the animator whether or not we're in the air
            animator.SetBool("IsOnGround", jumper.IsOnGround());
            //Tell the animator our current y velocity 
            animator.SetFloat("YVelocity", gameObject.GetComponent<Rigidbody2D>().velocity.y);
            //Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.y);
            //It uses all these things to decide which animation to play
        }
       

        //Listen for key presses and move left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            mover.AccelerateInDirection(new Vector2(-1, 0));
            spriteRenderer.flipX = false;
            if (animator != null)
            {
                //and tell the animator we are walking after all...
                animator.SetBool("Walking", true);
            }
        }

        //Listen for key presses and move right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            mover.AccelerateInDirection(new Vector2(1, 0));
            spriteRenderer.flipX = true;
            if (animator != null)
            {
                //and tell the animator we are walking after all...
                animator.SetBool("Walking", true);
            }
        }

        //Listen for key presses and jump
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            jumper.Jump();
            if (animator != null)
            {
                //and tell the animator to jump
                animator.SetBool("IsOnGround", jumper.IsOnGround());
            }
            //Play a Jump Sound
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            jumper.SetGravityReduced(true);
        }
        else
        {
            jumper.SetGravityReduced(false);
            if (animator != null)
            {
                //and tell the animator we are walking after all...
                animator.SetBool("IsOnGround", jumper.IsOnGround());
            }
        }

       
    }
}
