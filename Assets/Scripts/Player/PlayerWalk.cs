using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float Speed = 0;

    public float horizontal = 0;
    public float scale = 1;
    
    private Rigidbody2D rb;

    public float jumpspeed = 6f;

    public float FallGravity;
    public float GroundGravity;

    public float GroundSpeed = 7f;
    public float AirSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);

        Vector3 scaler = transform.localScale;

        if (scaler.x == 1 && rb.velocity.x < 0)
        { scaler.x *= -1; }
        else if (scaler.x == -1 && rb.velocity.x > 0)
        { scaler.x *= -1; }

        transform.localScale = scaler;

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = FallGravity;
        }
        else
        {
            rb.gravityScale = GroundGravity;
        }

       
        if ( rb.velocity.y != 0)
        {
            Speed = AirSpeed;
        }
        else
        {
            Speed = GroundSpeed;
        }



        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if( rb.velocity.y == 0 )
            {
               Vector2 jumper = rb.velocity;
               jumper.y = jumpspeed;
                rb.velocity = new Vector2(rb.velocity.x, jumper.y);
            }
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            horizontal = -Speed;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            horizontal = Speed;
        }

        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            horizontal = 0;
        }

    }
    
}