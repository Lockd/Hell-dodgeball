using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Meteor") {
            // TODO decrease interface counter
            // TODO set up menu if that was the last member of the group 
            
            Destroy(gameObject);
        }
    }
}
