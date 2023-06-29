using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private GameObject explosionObj;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    float speedToChangeTo;
    float currentVelocity;

    bool changingSpeed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1.5f;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Pipe"), LayerMask.NameToLayer("Pipe"), true);
    }

    private void Update()
    {
        if (GameManager.instance.gameOver) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //rb.velocity = Vector2.up * jumpForce * Mathf.Sign(rb.gravityScale); //Mathf.Sign(rb.gravityScale) return 1 or -1 make it go flip flip
            speedToChangeTo = jumpForce * Mathf.Sign(rb.gravityScale);
            currentVelocity = rb.velocity.y;
            changingSpeed = true;
        }

        if(changingSpeed && rb.velocity.y < (speedToChangeTo - 0.01f))
        {
            StartCoroutine(ChangeSpeed());
        }
        else
        {
            changingSpeed = false;
        }

        /*
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (rbody.gravityScale == 1.5f)
            {
                rbody.gravityScale = -1.5f;
            }
            else
            {
                rbody.gravityScale = 1.5f;
            }
        }
        */

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.gravityScale = 8f;
        }

        if (rb.gravityScale > 1.5f)
        {
            rb.gravityScale -= 0.1f;
        }

        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed); //rotate according to speed
    }

    IEnumerator ChangeSpeed()
    {
        var t = 0.0f;
        while (t <= 1.0f)
        {
            t += 8f * Time.deltaTime;
            rb.velocity = new Vector2(0, Mathf.Lerp(rb.velocity.y, speedToChangeTo, t));
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Pipe") || collision.gameObject.layer == LayerMask.NameToLayer("Wall")) //if the collision happened with a pipe
        {
            rb.constraints = RigidbodyConstraints2D.None; // make plane bounce around
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Pipe"), LayerMask.NameToLayer("Pipe"), false);

            //explosion
            GameObject obj = Instantiate(explosionObj, transform.position, Quaternion.identity);
            Destroy(obj, 5f); //destroy explosion after 5 seconds

            rb.AddForce(new Vector2(Random.Range(2, 5), Random.Range(2, 5)), ForceMode2D.Impulse); //push plane to upper right so it doesnt stay still
            GameManager.instance.GameOver();
        }

        PipeSpawner ps = FindObjectOfType<PipeSpawner>();
        ps.maxTime = 0.1f;
        ps.NineEleven();
    }
}