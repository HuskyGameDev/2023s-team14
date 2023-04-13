using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 velocity;
    [SerializeField] ParticleSystem explosion;

    public int targetScene = 1;
    public GameObject model;
    public GameObject thrust;

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

        if ((other.gameObject.tag == "Ground" && Mathf.Abs(playerCollisionSpeed) > 8f) || other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<AudioManager>().Play("rocket_explode_sound");
            model.SetActive(false);
            thrust.SetActive(false);
            explosion.Play();
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(targetScene);
    }
}
