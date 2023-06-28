using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    //[SerializeField] private float maxTime = 3f; game is too easy spawn more
    [SerializeField] private float heightRange;
    [SerializeField] private GameObject pipeObj;

    public float maxTime;

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    private float timer;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if(timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject pipe = Instantiate(pipeObj, spawnPos, Quaternion.identity);

        MovePipe mp = pipe.GetComponent<MovePipe>();
        mp.pipeSpeed = Random.Range(minSpeed, maxSpeed);

        Destroy(pipe, 10f);
    }

    public void NineEleven()
    {
        minSpeed = 20f;
        maxSpeed = 30f;
    }
}
