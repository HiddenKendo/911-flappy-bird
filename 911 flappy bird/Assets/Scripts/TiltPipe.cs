using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPipe : MonoBehaviour
{
    private float maxRot = 20;
    private float maxSpeed = 10;
    
    private float rotationSpeed;
    private float rotationAngle;

    private void Start()
    {
        rotationAngle = Random.Range(-maxRot, maxRot);
        rotationSpeed = Random.Range(-maxSpeed, maxSpeed);

        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
