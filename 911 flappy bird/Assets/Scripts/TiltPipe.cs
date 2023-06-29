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

    void Start()
    {
        rotationAngle = Random.Range(minRot, maxRot);
        rotationSpeed = Random.Range(minSpeed, maxSpeed);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
