using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitionHandler : MonoBehaviour
{
    float initVertExtent;
    float initHorzExtent;
    public float vertExtent;
    public float horzExtent;
    float yOffset;
    float xOffset;
    public GameObject player;
    public Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        initVertExtent = Camera.main.orthographicSize;
        initHorzExtent = initVertExtent * Screen.width / Screen.height;
        vertExtent = initVertExtent;
        horzExtent = initHorzExtent;
        playerPos = player.transform.position;
        xOffset = horzExtent * 2;
        yOffset = vertExtent * 2;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        if (playerPos.y > vertExtent - initVertExtent)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
            vertExtent += yOffset;
        }

        else if(playerPos.y < vertExtent -initVertExtent - initVertExtent * 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - yOffset, transform.position.z);
            vertExtent -= yOffset;
        }

        else if(playerPos.x > horzExtent)
        {
            transform.position = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z);
            horzExtent += xOffset;
        }

        else if (playerPos.x < horzExtent - initHorzExtent * 2)
        {
            transform.position = new Vector3(transform.position.x - xOffset, transform.position.y, transform.position.z);
            horzExtent -= xOffset;
        }

        Debug.Log("Vert: " + vertExtent);
        Debug.Log("Horz: " + horzExtent);
    }
}
