using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehaviour : MonoBehaviour
{
    public GameObject overheadFire;

    Animator anim;
    GameObject fireball;

    public GameObject spawnPosition;

    float lastMeteorSpawned;
    public float timeInterval = 1.5f;
    public float deltaTime = .1f;
    public float minTimeInterval = .3f;
    public float impactRadius = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
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
        GameObject meteor = Instantiate(overheadFire, spawnPosition.transform.position, Quaternion.identity);
        meteor.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f);
        updateSpawningTime();
        Destroy(meteor, 1f);
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


}

