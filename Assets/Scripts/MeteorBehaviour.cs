using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float minMeteorSpeed = 3f;
    [SerializeField] private float maxMeteorSpeed = 5f;
    [HideInInspector] public Vector2 destinationPosition;
    [HideInInspector] public ImpactIndicator impactIndicator;
    float distance;
    float speed;
    Vector2 movementDirection;

    public float time;
        
    void Start() {
        distance = Vector3.Distance(gameObject.transform.position, destinationPosition);

        movementDirection = new Vector2(
            destinationPosition.x - transform.position.x,
            destinationPosition.y - transform.position.y
        ).normalized;

        speed = Random.Range(minMeteorSpeed, maxMeteorSpeed);
    }
    
    void Update()
    {
        rb.velocity = movementDirection * speed;

        float remainingDistance = Vector3.Distance(transform.position, destinationPosition);
        impactIndicator.remainingDistance = remainingDistance;

        if (transform.position.y <= destinationPosition.y + 0.5f) {
            ScoreCounter.increaseScore();
            impactIndicator.GetComponent<Collider2D>().enabled = true;
            Destroy(impactIndicator.gameObject, time);
            //impactIndicator.onDestroy();
            Destroy(gameObject);
        }
    }
}
