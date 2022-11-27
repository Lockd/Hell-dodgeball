using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private GameObject impactIndicatorPrefab;
    [SerializeField] private GameObject topLeftPosition;
    [SerializeField] private GameObject bottomRightPosition;
    [SerializeField] private float timeInterval = 1.5f;
    [SerializeField] private float deltaTime = .1f;
    [SerializeField] private float minTimeInterval = .3f;
    [SerializeField] private float impactRadius = 1.5f;
    [SerializeField] private int amountOfMeterosToSpawn = 3;
    float xMax;
    float xMin;
    float yMax;
    float yMin;
    float lastMeteorSpawned = 0f;
    [SerializeField] private float increaseMeteorAmountAfter = 60f;
    float increasedMeteorTime = 0f;

    void Start()
    {
        xMax = bottomRightPosition.transform.position.x - impactRadius * 1.7f;
        xMin = topLeftPosition.transform.position.x + impactRadius * 1.7f;
        yMax = topLeftPosition.transform.position.y - impactRadius;
        yMin = bottomRightPosition.transform.position.y + impactRadius;
        
        increasedMeteorTime = Time.time;
    }

    void Update()
    {
        if (Time.time > lastMeteorSpawned + timeInterval)
        {
            for (int i = 0; i < amountOfMeterosToSpawn; i++)
            {
                spawnMeteor();
            }
        }

        if (Time.time > increasedMeteorTime + increaseMeteorAmountAfter) {
            increasedMeteorTime = Time.time + increaseMeteorAmountAfter;
            amountOfMeterosToSpawn++;
        }
    }

    void spawnMeteor()
    {
        // Spawn meteor itself
        Vector3 destinationPosition = getDestinationPosition();
        Vector3 initialMeteorPosition = getInitialMeteorPosition(destinationPosition);
        
        Vector3 rotateTowards = new Vector3(0f, 0f, 0f);
        rotateTowards.x = destinationPosition.x - initialMeteorPosition.x;
        rotateTowards.y = destinationPosition.y - initialMeteorPosition.y;
        float angle = Mathf.Atan2(rotateTowards.y, rotateTowards.x) * Mathf.Rad2Deg;
        
        GameObject meteor = Instantiate(meteorPrefab, initialMeteorPosition, Quaternion.Euler(new Vector3(0, 0, angle)));
        MeteorBehaviour meteorBehaviour = meteor.GetComponent<MeteorBehaviour>();
        meteorBehaviour.destinationPosition = new Vector2(destinationPosition.x, destinationPosition.y);
        // Spawn impact indicator
        GameObject impactIndicatorGameObject = Instantiate(impactIndicatorPrefab, destinationPosition, Quaternion.identity);
        ImpactIndicator impactIndicator = impactIndicatorGameObject.GetComponent<ImpactIndicator>();
        impactIndicator.initialMeteorPosition = initialMeteorPosition;
        meteorBehaviour.impactIndicator = impactIndicator;
        // Change meteor spawning timer
        updateSpawningTime();
    }

    void updateSpawningTime()
    {
        lastMeteorSpawned = Time.time;
        timeInterval -= deltaTime;
        if (timeInterval < minTimeInterval)
        {
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
        Vector3 meteorDestionation = new Vector3(x, y, 0f);
        return meteorDestionation;
    }
}
