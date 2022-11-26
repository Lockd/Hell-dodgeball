using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactIndicator : MonoBehaviour
{
    public float maxScale = 1.7f;
    [HideInInspector] public Vector3 initialMeteorPosition;
    [HideInInspector] public float remainingDistance;
    public ParticleSystem impactParticleSystem;
    float initialDistance;
    float initialScale;
    float scaleDifference;
    SpriteRenderer sprite;
    Collider2D _collider;
    
    void Start()
    {
        initialDistance = Vector3.Distance(transform.position, initialMeteorPosition);
        initialScale = transform.localScale.x;
        scaleDifference = maxScale - initialScale;
        sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        float scaleRatio = 1 - remainingDistance / initialDistance;
        float scaleX = scaleDifference * scaleRatio + initialScale;
        float scaleY = scaleX / 2;
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }

    public void onDestroy() {
        _collider.enabled = true;
        impactParticleSystem.Play();
        sprite.enabled = false;
        Destroy(gameObject, impactParticleSystem.main.duration - 0.1f);
    }
}
