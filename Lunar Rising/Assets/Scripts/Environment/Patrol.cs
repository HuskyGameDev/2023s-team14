using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigidbody;
    Transform transform;

    bool inSheepClip = false;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (IsFacingRight())
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        } else
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.tag == "Player")
        //{
        //    if ((transform.position.y > collision.collider.gameObject.transform.position.y)) // Sheep clip.
        //    {
        //        collision.collider.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(0f, 2200f));
        //        // collision.collider.enabled = false;
        //        inSheepClip = true;
        //    }
        //}
    }
}
