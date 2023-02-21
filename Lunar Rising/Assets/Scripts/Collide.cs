using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with something");
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collided with obstacle");
            player.SetActive(false);
        }
    }
}
