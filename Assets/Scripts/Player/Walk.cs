using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Walk : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    public float jump = 0;
    public float slide = 0;
    //bool facingRight = true;
    bool ground;
    bool wall;
    bool jumpControl;
    bool isWalking = false;
    public Animator gloveAnim;
    public Animator catAnim;
    public Animator manavAnim;
    public PlayerPosseser playerPosseser;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput < 0)
        {
            flipToRight();
        }
        if (moveInput > 0)
        {
            flipToLeft();
        }

        if (moveInput != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }



        gloveAnim.SetBool("isWalking", isWalking);
        catAnim.SetBool("catisWalking", isWalking);
        manavAnim.SetBool("manavisWalking", isWalking);
        
        if (Input.GetButtonDown("Jump") && jumpControl == true && (ground == true || wall == true))
        {
            rb.AddForce(new Vector3(rb.velocity.x, jump));
            gloveAnim.SetTrigger("jumpIs");
            catAnim.SetTrigger("catjumpIs");
            wall = false;
            jumpControl = false;
        }

        gloveAnim.SetBool("onGround", ground);
        catAnim.SetBool("catonGround", ground);


        if (wall == true && ground == false)
        {
            transform.position += new Vector3(0, -1 * Time.deltaTime, 0);
            catAnim.SetBool("catonWall", true);
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
            catAnim.SetBool("catonWall", true);
        }
    }


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
            catAnim.SetBool("catonWall", false);
        }
    }

    void flipToRight()
    {
        //facingRight = true;
        transform.localScale = new Vector3(-1, 1, 1);
    }

    void flipToLeft()
    {
        //facingRight = false;
        transform.localScale = new Vector3(1, 1, 1);
    }
}