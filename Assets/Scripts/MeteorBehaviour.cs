using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    public Collider2D _collider;
    public Rigidbody2D rb;
    [HideInInspector] public Vector2 destinationPosition;
    [HideInInspector] public ImpactIndicator impactIndicator;
    float distance;
    Vector2 movementDirection;

    public float time;
        
    void Start() {
        _collider.enabled = false;
        distance = Vector3.Distance(gameObject.transform.position, destinationPosition);

        movementDirection = new Vector2(
            destinationPosition.x - transform.position.x,
            destinationPosition.y - transform.position.y
        );
    }
    
    void Update()
    {
        rb.velocity = movementDirection;

        float remainingDistance = Vector3.Distance(transform.position, destinationPosition);
        impactIndicator.remainingDistance = remainingDistance;

        /* Not Needed
        if (
            remainingDistance < 0.5f && 
            !_collider.enabled
        ) {
            _collider.enabled = true;
        }
        */

        if (transform.position.y <= destinationPosition.y + 0.5f) {
            ScoreCounter.increaseScore();
            impactIndicator.GetComponent<Collider2D>().enabled = true;
            Destroy(impactIndicator.gameObject, time);
            //impactIndicator.onDestroy();
            Destroy(gameObject);
        }
    }
}
