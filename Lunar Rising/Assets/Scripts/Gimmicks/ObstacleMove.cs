using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 100.0f)]
    float distance;
    [SerializeField]
    [Range(0.0f, 100.0f)]
    float speedX;
    [SerializeField]
    [Range(0.0f, 100.0f)]
    float speedY;
    Vector2 originalPos;
    [SerializeField] bool directionDownToggle = false;

    private void Start()
    {
        originalPos = transform.position;
    }

    private void Update()
    {
        if (!directionDownToggle)
        transform.position = new Vector3(Mathf.PingPong(Time.time * speedX, distance) + originalPos.x, Mathf.PingPong(Time.time * speedY, distance) + originalPos.y, 0f);
        else
            transform.position = new Vector3(-Mathf.PingPong(Time.time * speedX, distance) + originalPos.x, -Mathf.PingPong(Time.time * speedY, distance) + originalPos.y, 0f);
    }
}
