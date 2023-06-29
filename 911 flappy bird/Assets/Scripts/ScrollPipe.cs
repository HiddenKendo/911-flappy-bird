using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BROKEN SCRIPT PLS FIX

public class ScrollPipe : MonoBehaviour
{
    float scrollSpeed = 1f;
    private float height;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        height = 12; //dont change this number

        rb.velocity = new Vector2(rb.velocity.x, scrollSpeed); //change only the y
    }

    private void Update()
    {
        if (transform.position.y >= height)
        {
            // Set the object's position to the bottom of the screen
            transform.position = new Vector3(transform.position.x, -height, transform.position.z);
        }
    }
}