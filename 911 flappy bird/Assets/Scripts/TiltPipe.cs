using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPipe : MonoBehaviour
{
    [SerializeField] private float maxRot;
    [SerializeField] private float minRot;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    
    private float rotationSpeed;
    private float rotationAngle;

    private void Start()
    {
        rotationAngle = Random.Range(minRot, maxRot);
        rotationSpeed = Random.Range(minSpeed, maxSpeed);
        Debug.Log(rotationSpeed);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
