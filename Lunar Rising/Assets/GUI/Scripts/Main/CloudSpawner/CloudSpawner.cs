using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    [SerializeField] Sprite[] cloudSprite = new Sprite[5];
    GameObject cloudInstance;
    [SerializeField] float interval = 1f;
    float timeSinceSpawnedObject = Mathf.Infinity;
    [SerializeField] float minHeight = -4f, maxHeight = 4.75f;

    private void Update()
    {
        timeSinceSpawnedObject += Time.deltaTime;

        if (timeSinceSpawnedObject > interval)
        {
            cloudInstance = Instantiate(cloud, new Vector2(this.transform.position.x, Random.Range(minHeight, maxHeight)), Quaternion.identity);
            cloudInstance.GetComponent<SpriteRenderer>().sprite = cloudSprite[Random.Range(0, 5)];
            timeSinceSpawnedObject = 0f;
        }
    }
}
