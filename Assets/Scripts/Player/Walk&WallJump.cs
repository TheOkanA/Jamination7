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
        if (Input.GetButtonDown("Jump") && (ground == true || wall == true))
        {
            rb.AddForce(new Vector3(rb.velocity.x, jump));
            wall = false;
        }
        if (wall == true && ground == false)
        {
            rb.velocity = new Vector3(rb.velocity.x, -slide);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Map"))
        {
            ground = true;

        }
        if (other.CompareTag("Wall"))
        {
            Invoke(nameof(WallTruer), 3f);
        }
    }

    private void WallTruer()
    {
        wall = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Map"))
        {
            ground = false;
        }
        if (other.CompareTag("Wall"))
        {
            wall = false;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}