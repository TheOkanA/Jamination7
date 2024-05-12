using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    public float jump = 0;
    public float slide = 0;
    bool facingRight = true;
    bool ground;
    bool wall;
    bool jumpControl;
    public GameObject rotationer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput < 0 && facingRight)
        {
            flip();
        }
        if (moveInput > 0 && !facingRight)
        {
            flip();
        }


        if (Input.GetButtonDown("Jump") && jumpControl== true && (ground == true || wall == true))
        {
            rb.AddForce(new Vector3(rb.velocity.x, jump));
            wall = false;
            jumpControl = false;
        }


        if (wall == true && ground == false)
        {
            transform.position += new Vector3(0, -1 * Time.deltaTime, 0);
        }
        if(wall == false && ground == true)
        {
            jumpControl = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Map"))
        {
            ground = true;
            jumpControl = true;
        }

        if (other.CompareTag("Wall"))
        {
            wall = true;
            jumpControl = true;
        }
    }

    //private void WallTruer()
    //{
    //    wall = true;
    //}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Map"))
        {
            ground = false;
        }
        jumpControl = false;
        if (other.CompareTag("Wall"))
        {
            wall = false;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        rotationer.transform.Rotate(0, 180, 0);
    }
}