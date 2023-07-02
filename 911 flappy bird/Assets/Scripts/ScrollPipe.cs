using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPipe : MonoBehaviour
{
    float minSpeed = 0.8f;
    float maxSpeed = 1f;
    private float scrollSpeed;

    private const float height = 12; //dont change this number

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        int direction; // the direction the pipe scrolls is dependent on its spawn in y-axis to prevent impossible spawns
        if (transform.position.y > 1.1f)
        {
            direction = -1;
        }
        else if (transform.position.y < -1.1f)
        {
            direction = 1;
        }
        else
        {
            direction = ((Random.Range(0, 2) * 2) - 1); // better random -1 or 1
        }

        scrollSpeed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = new Vector2(rb.velocity.x, direction * scrollSpeed); //change only the y
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