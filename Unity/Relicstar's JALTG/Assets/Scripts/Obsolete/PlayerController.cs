using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

//code writen by annoyedbark
// if used credit me pls, also, this code is super gross and messy, might do a refactor, but idk
public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb2D;
    public Animator animator;
    public SpriteRenderer SpriteRenderer;

    
    public float moveSpeed;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;
    private bool isWall;
    public float checkRadius2;
    public Transform wallCheck;

   

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    

//TODO: Left/right movement, Jump

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();

        //initialization, the sequel!

    }
    
    private void Update()
    {
        //lines 46-75 are for jump physics 
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2D.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb2D.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                //animator.Play("jump");

            }
            else
            {
                isJumping = false;
            }

            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            animator.Play("idle");
        }

      /*  isWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius2, whatIsWall);
        if(isWall == true)
        {
            rb2D.velocity = new Vector2(0, 0);

        } */

        
    }
    private void FixedUpdate()//for movement
    {
        //sorry for the amount of if statments, might optimise later, but for now... cry about it

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(moveSpeed,rb2D.velocity.y); //for right sided movement
            //animator.Play("Run");
            SpriteRenderer.flipX = false;

        }
          else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-moveSpeed, rb2D.velocity.y); //left movement
            //animator.Play("Run");  temporarily disabled until we have all animations
            SpriteRenderer.flipX = true;
        }

        else
        {
            if(isJumping == true)
            {
               // animator.Play("jump");
            }
            else
            {
                animator.Play("idle");
            }
            
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);//resets to zero when not moving so there is no slipperiness(is that a word??)

        }
       
    }



}

