using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehviour : MonoBehaviour
{
    [SerializeField] private float positionDelta = 1f;
    [SerializeField] private float speed = 0.3f;
    Vector3 initialPosition;
    Vector3 maxPosition;
    bool isGoingUp = true;

    void Start()
    {
        initialPosition = transform.position;
        maxPosition = initialPosition + new Vector3(0f, positionDelta, 0f);
    }

    void FixedUpdate()
    {
        float deltaMovement = speed * Time.deltaTime;
        if (!isGoingUp) {
            deltaMovement *= -1;
        }
        transform.position += new Vector3(0f, deltaMovement, 0f);
        
        if (transform.position.y > maxPosition.y) isGoingUp = false;
        if (transform.position.y < initialPosition.y) isGoingUp = true;
    }
}
