using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Plane : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Rigidbody2D rbody;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 1.5f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce * Math.Sign(rbody.gravityScale); // (rbody.gravityScale) divide by 1.5f to get the polarity of the gravity
        }


        if (rbody.gravityScale > 1.5f)
        {
            rbody.gravityScale -= 0.1f;
        }

        /*
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (rbody.gravityScale == 1.5f)
            {
                rbody.gravityScale = -1.5f;
            }
            else
            {
                rbody.gravityScale = 1.5f;
            }
        }
        */

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rbody.gravityScale = 10f;
        }

    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.constraints = RigidbodyConstraints2D.None;
        this.enabled = false;

        GameManager.instance.GameOver();
    }
}
