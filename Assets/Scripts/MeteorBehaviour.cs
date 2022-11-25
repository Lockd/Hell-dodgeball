using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    public BoxCollider2D _collider;
    public float impactRadius = 1.5f;
    [HideInInspector] public Vector3 destinationPoint;
    public GameObject topLeftPosition;
    public GameObject bottomRightPosition;
    float xMax;
    float xMin;
    float yMax;
    float yMin;


    void Start() {
        _collider.gameObject.SetActive(false);

        xMax = bottomRightPosition.transform.position.x;
        xMin = topLeftPosition.transform.position.x;
        yMax = topLeftPosition.transform.position.y;
        yMin = bottomRightPosition.transform.position.y;
    }
    
    void Update()
    {
        if (
            Vector3.Distance(transform.position, destinationPoint) < 0.5 && 
            !_collider.gameObject.activeInHierarchy
        ) {
            _collider.gameObject.SetActive(true);
        }
    }
}
