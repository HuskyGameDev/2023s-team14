using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleDrop : MonoBehaviour
{
    public float force = 1f;
    public float detectionDistance = 5f;
    Rigidbody2D rb;
    Vector2 startingPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPos = transform.position;
        rb.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, detectionDistance);
        Debug.DrawRay(transform.position, Vector2.down, Color.red, 2f);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                rb.gravityScale = 1;
                rb.AddForce(Vector3.down * force);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.tag == "Ground" || collision.collider.tag == "Obstacle") && rb.gravityScale == 1)
        {
            transform.position = new Vector3(-20f, 0f, 0f);
            rb.gravityScale = 0;
            StartCoroutine(WaitToRespawn(3f));
        }
    }

    IEnumerator WaitToRespawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = startingPos;
    }
}
