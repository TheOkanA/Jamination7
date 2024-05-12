using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTruck : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Transform teker1Transform;
    private Transform teker2Transform;
    float wheelSpeed;

    private void Awake()
    {
        teker1Transform = transform.Find("teker1");
        teker2Transform = transform.Find("teker2");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);


        float rotationDegreesPerDay = 360f;
        wheelSpeed += Time.deltaTime;

        if (moveInput > 0)
        {
            teker1Transform.eulerAngles = new Vector3(0, 0, -wheelSpeed * rotationDegreesPerDay);
            teker2Transform.eulerAngles = new Vector3(0, 0, -wheelSpeed * rotationDegreesPerDay);
        }
        if (moveInput < 0)
        {
            teker1Transform.eulerAngles = new Vector3(0, 0, wheelSpeed * rotationDegreesPerDay);
            teker2Transform.eulerAngles = new Vector3(0, 0, wheelSpeed * rotationDegreesPerDay);
        }



    }
}
