using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    //[SerializeField] private float speed = 3.5f; game is too easy
    public float pipeSpeed;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * pipeSpeed;
    }
}
