using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    //[SerializeField] private float speed = 3.5f; game is too easy
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float pipeSpeed;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pipeSpeed = Random.Range(minSpeed, maxSpeed);

        rb.velocity = Vector2.left * pipeSpeed;
    }
}
