using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    [SerializeField] float minCloudSpeed = 1f;
    [SerializeField] float maxCloudSpeed = 5f;
    private float randomSpeed = 0f;

    void Start()
    {
        randomSpeed = Random.Range(minCloudSpeed, maxCloudSpeed);
    }

    void Update()
    {
        transform.Translate(new Vector2(randomSpeed * Time.deltaTime, 0f));

        if (transform.position.x > 15f)
            Destroy(this.gameObject);
    }
}
