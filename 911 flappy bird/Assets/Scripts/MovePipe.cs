using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    //[SerializeField] private float speed = 3.5f; game is too easy
    [SerializeField] private float minSpeed = 10f;
    [SerializeField] private float maxSpeed = 14f;
    [SerializeField] private float pipeSpeed = 10f;

    private void Start()
    {
        pipeSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        //transform.position += Vector3.left * speed * Time.deltaTime; boring game need more randomness
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
    }
}
