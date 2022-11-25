using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameObject impactIndicatorPrefab;
    public GameObject topLeftPosition;
    public GameObject bottomRightPosition;
    public float timeInterval = 1.5f;
    public float deltaTime = .1f;
    public float minTimeInterval = .3f;
    public float impactRadius = 1.5f;
    float xMax;
    float xMin;
    float yMax;
    float yMin;
    float lastMeteorSpawned = 0f;

    void Start()
    {
        xMax = bottomRightPosition.transform.position.x - impactRadius*1.7f;
        xMin = topLeftPosition.transform.position.x + impactRadius*1.7f;
        yMax = topLeftPosition.transform.position.y - impactRadius;
        yMin = bottomRightPosition.transform.position.y + impactRadius;
    }

    void Update()
    {
        if (Time.time > lastMeteorSpawned + timeInterval)
        {
            spawnMeteor();
        }
    }

    void spawnMeteor()
    {
        // Spawn meteor itself
        Vector3 destinationPosition = getDestinationPosition();
        Vector3 initialMeteorPosition = getInitialMeteorPosition(destinationPosition);
        GameObject meteor = Instantiate(meteorPrefab, initialMeteorPosition, Quaternion.identity);
        MeteorBehaviour meteorBehaviour = meteor.GetComponent<MeteorBehaviour>();
        meteorBehaviour.destinationPosition = new Vector2 (destinationPosition.x, destinationPosition.y);
        // Spawn impact indicator
        GameObject impactIndicatorGameObject = Instantiate(impactIndicatorPrefab, destinationPosition, Quaternion.identity);
        ImpactIndicator impactIndicator = impactIndicatorGameObject.GetComponent<ImpactIndicator>();
        impactIndicator.initialMeteorPosition = initialMeteorPosition;

        meteorBehaviour.impactIndicator = impactIndicator;
        // Change meteor spawning timer
        updateSpawningTime();
    }

    void updateSpawningTime() {
        lastMeteorSpawned = Time.time;
        timeInterval -= deltaTime;
        if (timeInterval < minTimeInterval) {
            timeInterval = minTimeInterval;
        }
    }

    Vector3 getInitialMeteorPosition(Vector3 destinationPosition)
    {
        float x = destinationPosition.x + Random.Range(-1.5f, 1.5f);
        float y = destinationPosition.y + Random.Range(10f, 18f);
        return new Vector3(x, y, 0f);
    }

    Vector3 getDestinationPosition()
    {
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        return new Vector3(x, y, 0f);
    }
}
