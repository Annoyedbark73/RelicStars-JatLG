using System.Collections;
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
}
