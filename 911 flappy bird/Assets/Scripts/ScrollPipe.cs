using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPipe : MonoBehaviour
{
    float scrollSpeed = 1f;
    private const float height = 12; //dont change this number

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        int random;
        if (Random.Range(1, 3) == 1) //1 to 2
            random = -1;
        else random = 1;

        //Debug.Log(random);

        rb.velocity = new Vector2(rb.velocity.x, random * scrollSpeed); //change only the y
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