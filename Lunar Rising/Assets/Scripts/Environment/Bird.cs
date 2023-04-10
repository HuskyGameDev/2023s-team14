using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bird : MonoBehaviour
{
    Vector3 pointA;
    Vector3 pointB;
    public bool MoveBack;
    NavMeshAgent Object;
    float distanceToTravel;
    [SerializeField] float speed;
    [SerializeField] Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        Object = gameObject.GetComponent<NavMeshAgent>();
        distanceToTravel = Camera.main.orthographicSize * Screen.width / Screen.height;
        pointA = new Vector3(-distanceToTravel, transform.position.y, 0f);
        pointB = new Vector3(distanceToTravel, transform.position.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveBack == false)
        {
            transform.position += new Vector3(-direction.x, direction.y, 0f) * Time.deltaTime * speed;
            if (transform.position.x <= pointA.x)
            {
                MoveBack = true;
                transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
            }
        }
        else
        {
            transform.position -= new Vector3(-direction.x, direction.y, 0f) * Time.deltaTime * speed;
            if (transform.position.x >= pointB.x)
            {
                MoveBack = false;
                transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
        }
    }
}
