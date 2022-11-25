using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactIndicator : MonoBehaviour
{
    public float scaleSpeed = 0.5f;
    public float maxScale = 1.7f;
    [HideInInspector] public Vector3 initialMeteorPosition;
    [HideInInspector] public float remainingDistance;
    float initialDistance;
    float initialScale;
    float scaleDifference;

    void Start()
    {
        initialDistance = Vector3.Distance(transform.position, initialMeteorPosition);
        initialScale = transform.localScale.x;
        scaleDifference = maxScale - initialScale;
    }

    void Update()
    {
        float scaleRatio = 1 - remainingDistance / initialDistance;
        float scaleX = scaleDifference * scaleRatio + initialScale;
        float scaleY = scaleX / 2;
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }

    public void onDestroy() {
        Destroy(gameObject);
    }
}
