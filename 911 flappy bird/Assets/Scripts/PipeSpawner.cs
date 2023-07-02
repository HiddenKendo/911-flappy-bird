using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    //[SerializeField] private float maxTime = 3f; game is too easy spawn more
    [SerializeField] private float heightRange;
    [SerializeField] private GameObject pipeObj, scrollPipeObj;

    public float maxTime; //public so it can be made faster when game over

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

        GameObject pipe;

        int random = Random.Range(0, 100);
        if(random < 80) //spawn the pipe
        {
            pipe = Instantiate(pipeObj, spawnPos, Quaternion.identity);
            MovePipe mp = pipe.GetComponent<MovePipe>();
            mp.pipeSpeed = Random.Range(minSpeed, maxSpeed);

            int randomizer = Random.Range(0, 100);
            if (randomizer < 30)
            {
                //make it a tilted tower
                pipe.gameObject.AddComponent<TiltPipe>();

                SpriteRenderer[] towerSprite = pipe.GetComponentsInChildren<SpriteRenderer>(); //get the sprite renderers of all the children
                foreach (SpriteRenderer item in towerSprite) //change the colour for each sprite renderer it found
                {
                    item.color = new Color32(45, 212, 227, 255);
                }
            }
            else if (randomizer < 50)
            {
                pipe.gameObject.AddComponent<StutterPipe>();
                mp.pipeSpeed = 0f;
                SpriteRenderer[] towerSprite = pipe.GetComponentsInChildren<SpriteRenderer>(); //get the sprite renderers of all the children
                foreach (SpriteRenderer item in towerSprite) //change the colour for each sprite renderer it found
                {
                    item.color = new Color32(255, 154, 46, 255);
                }
            }
        }
        else
        {
            //scroll pipe
            pipe = Instantiate(scrollPipeObj, spawnPos, Quaternion.identity);
            MovePipe mp = pipe.GetComponent<MovePipe>();
            mp.pipeSpeed = Random.Range(minSpeed, maxSpeed);
        }
        Destroy(pipe, 5f);
    }

    public void NineEleven()
    {
        minSpeed = 20f;
        maxSpeed = 30f;
    }
}
