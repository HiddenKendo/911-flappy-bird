using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPipe : MonoBehaviour
{
    private float rot = 20;
    private float minSpeed = 5;
    private float maxSpeed = 12;

    private float rotationSpeed;
    private float rotationAngle;

    private void Start()
    {

        rotationAngle = Random.Range(-rot, rot);
        rotationAngle = rotationAngle * RandomPolarity();

        rotationSpeed = Random.Range(minSpeed, maxSpeed);
        rotationSpeed = rotationSpeed * RandomPolarity();

        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private static int RandomPolarity()
    {
        if (Random.Range(1, 3) == 1) //1 to 2
            return -1;
        else 
            return 1;
    }
}


