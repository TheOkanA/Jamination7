using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRigidBody : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        boxCollider2D.isTrigger = false;
    }
}
