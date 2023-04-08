using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 velocity;
    [SerializeField] ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector2(Mathf.Abs(rb.velocity.x), Mathf.Abs(rb.velocity.y));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 collisionNormal = (other.transform.position - transform.position).normalized;

        float playerCollisionSpeed = Vector2.Dot(collisionNormal, velocity);

        if (other.gameObject.tag == "Obstacle" && Mathf.Abs(playerCollisionSpeed) > 2f)
        {
            FindObjectOfType<AudioManager>().Play("rocket_explode_sound");
            explosion.Play();
            // TODO: Reset player after a delay
            // TODO: Disallow input from the player
        }
    }
}
