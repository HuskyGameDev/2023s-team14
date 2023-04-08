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

    private void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(speedX * Time.time, distance), Mathf.PingPong(speedY * Time.time, distance), 0f);
    }
}
