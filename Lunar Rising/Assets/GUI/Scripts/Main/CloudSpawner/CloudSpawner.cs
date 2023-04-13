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
    float cameraYPos;
    float playerYPos;
    [SerializeField] GameObject player;
    [SerializeField] float cloudSize = 1f;

    private void Start()
    {
        cameraYPos = Camera.main.transform.position.y;
        playerYPos = player.transform.position.y;
    }

    private void Update()
    {
        cameraYPos = Camera.main.transform.position.y;
        playerYPos = player.transform.position.y;
        timeSinceSpawnedObject += Time.deltaTime;

        if (timeSinceSpawnedObject > interval)
        {
            if (playerYPos >= gameObject.transform.position.y - 5f && playerYPos < gameObject.transform.position.y + 5f)
            {
                cloudInstance = Instantiate(cloud, new Vector2(this.transform.position.x, Random.Range(cameraYPos - 5f, cameraYPos + 5f)), Quaternion.identity);
                cloudInstance.GetComponent<SpriteRenderer>().sprite = cloudSprite[Random.Range(0, 5)];
                cloudInstance.transform.localScale = new Vector3(cloudSize, cloudSize, cloudSize);
                timeSinceSpawnedObject = 0f;
            }
        }
    }
}
