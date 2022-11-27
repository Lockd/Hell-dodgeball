using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsSpawnerBehviour : MonoBehaviour
{
    [SerializeField] private float minTimeSpawn = 12f;
    [SerializeField] private float maxTimeSpawn = 20f;
    [SerializeField] private GameObject heartBuff;
    [SerializeField] private GameObject topLeftPosition;
    [SerializeField] private GameObject bottomRightPosition;
    [SerializeField] private float positionPadding = 5f;
    float xMax;
    float xMin;
    float yMax;
    float yMin;
    float spawnBuffAfter;

    void Start()
    {
        xMax = bottomRightPosition.transform.position.x - positionPadding;
        xMin = topLeftPosition.transform.position.x + positionPadding;
        yMax = topLeftPosition.transform.position.y - positionPadding;
        yMin = bottomRightPosition.transform.position.y + positionPadding;

        spawnBuffAfter = Time.time + getSpawnTimeDelta();
    }

    float getSpawnTimeDelta()
    {
        return Random.Range(minTimeSpawn, maxTimeSpawn);
    }
    
    void Update()
    {
        if (Time.time > spawnBuffAfter) {
            spawnBuff();
        }
    }

    void spawnBuff()
    {
        spawnBuffAfter = getSpawnTimeDelta() + Time.time;
        Instantiate(heartBuff, getDestinationPosition(), Quaternion.identity);
    }

    Vector3 getDestinationPosition()
    {
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        return new Vector3(x, y, 0f);
    }
}
