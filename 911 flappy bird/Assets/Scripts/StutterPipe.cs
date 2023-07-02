using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StutterPipe : MonoBehaviour
{
    private float stutterDelay = 0.05f; // delay for pipe to move
    private float moveDistance = 0.4f; // distance pipe moves
    private float randomizedMoveX;
    private float randomizedMoveY;

    private int moveCancelsChaos = -1;
    private float chaosDirection;

    private float timer;
    private int iteration = 0;

    private bool stopChaos = false;
    
    void Update()
    {
        if (timer > stutterDelay)
        {
            if (moveCancelsChaos != iteration)
            {
                // 10% chance for a burst of chaos which makes the pipe look less predictable
                if (Random.Range(0, 100) < 90)
                {
                    randomizedMoveX = moveDistance + Random.Range(-0.1f, 0.2f);
                }
                else
                {
                    randomizedMoveX = moveDistance + Random.Range(0.75f, 1.25f);
                }

                // 20% chance, be careful with this one it can get very fustrating if the range is too high
                if (Random.Range(0, 100) < 80)
                {
                    randomizedMoveY = Random.Range(-0.1f, 0.1f);
                }
                else
                {
                    // Huge spazz only happens early on and once per stutter pipe
                    if (iteration < 10 && !stopChaos)
                    {
                        chaosDirection = (Random.Range(0, 2) * 2) - 1;
                        randomizedMoveY = chaosDirection;
                        stopChaos = true; // spazz only once
                    }
                    else
                    {
                        randomizedMoveY = Random.Range(-0.2f, 0.2f);
                    }
                }

                // After a huge spazz, 50% chance for the pipe's y to cancel out the spazz a couple frames from now
                if (Mathf.Abs(randomizedMoveY) == 1f && Random.Range(0, 2) == 1)
                {
                    moveCancelsChaos = iteration + Random.Range(6, 10);
                }

                transform.position = new Vector2(transform.position.x - randomizedMoveX, transform.position.y + randomizedMoveY);
            }
            else // cancel out pipe y's spazz
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - chaosDirection);
            }
            
            iteration++;
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
    
}
