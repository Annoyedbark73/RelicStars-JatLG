/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//all code by annoyedbark :D if you have a question or wish to ask something email me at Annoyedbark73@gmail.com 
public class PlayerMovement : MonoBehaviour
{

  public Rigidbody2D Rigidbody2D;
   public SpriteRenderer spriteRenderer;
   public CapsuleCollider2D Collider;
   public LayerMask groundLayer;
   public LayerMask wallLayer;

   private float horizontalInput;
   public float jumpHeight;
   public float moveSpeed;




   public void Awake()
   {
      Rigidbody2D = GetComponent<Rigidbody2D>();
       spriteRenderer = GetComponent<SpriteRenderer>();
       Collider = GetComponent<CapsuleCollider2D>();


   }

   // Update is called once per frame
   // detect and execute movement
   void Update()
   {
       horizontalInput = Input.GetAxisRaw("Horizontal");
       Rigidbody2D.velocity = new Vector2( horizontalInput * moveSpeed,Rigidbody2D.velocity.y);


       if (Input.GetKeyDown(KeyCode.A))  //flips player depending on movement
       {
           spriteRenderer.flipX = true;
       }
       else if (Input.GetKeyDown(KeyCode.D))
       {
           spriteRenderer.flipX = false;
       }

       if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
       {
          
           Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x,jumpHeight);
       }
        print(OnWall());
   }

   public bool isGrounded()
   {
       RaycastHit2D raycastHit = Physics2D.CapsuleCast(Collider.bounds.center, Collider.bounds.size, 0, 0.1f, Vector2.down,groundLayer);
           return raycastHit.collider != null;
   }
   public bool OnWall()
   {
       RaycastHit2D raycastHit = Physics2D.CapsuleCast(Collider.bounds.center, Collider.bounds.size, 0, 0.1f, new Vector2(transform.localScale.x, 0),wallLayer);
       return raycastHit.collider != null;
   }
} */
using UnityEngine;

/*public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    public SpriteRenderer spriteRenderer;
     public LayerMask groundLayer;
     public LayerMask wallLayer;

    public Rigidbody2D body;
   

    public CapsuleCollider2D CapsuleCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        CapsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))  //flips player depending on movement
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }
        


        //Wall jump logic
        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 7;
            }
                

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
                
        }
        else
            wallJumpCooldown += Time.deltaTime;

        //print(onWall());

        if (isGrounded())
        {
            Debug.Log("worked");
        }
        else
        {
            Debug.Log("trolled");
        }
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(CapsuleCollider.bounds.center, CapsuleCollider.bounds.size, 0, 0.1f, Vector2.down, groundLayer);
        return raycastHit.collider != null;
        
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(CapsuleCollider.bounds.center,CapsuleCollider.bounds.size, 0,0.1f, new Vector2(transform.localScale.x, 0) , wallLayer);
        return raycastHit.collider != null;
    }
} */


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;

    private float wallJumpCooldown;
    private float horizontalInput;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

       

       
        //Wall jump logic
        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 7;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
           
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
        }
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    
}
