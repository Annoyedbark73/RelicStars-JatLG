using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float horizontalInput;
    public float jumpHeight;
    public float moveSpeed;
    public Rigidbody2D Rigidbody2D;
    
    public void Awake()
    {
       Rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x,jumpHeight);
        }
    }
}
