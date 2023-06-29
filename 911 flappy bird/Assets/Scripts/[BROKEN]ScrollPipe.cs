using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BROKEN SCRIPT PLS FIX

public class ScrollPipe : MonoBehaviour
{
    public float scrollSpeed = 1f;
    private float screenHeight;

    private void Start()
    {
        screenHeight = Camera.main.orthographicSize;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        if (transform.position.y >= screenHeight)
        {
            // Set the object's position to the bottom of the screen
            transform.position = new Vector3(transform.position.x, -screenHeight, transform.position.z);
        }
    }
}