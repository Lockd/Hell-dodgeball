using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInitializator : MonoBehaviour
{
    public GameObject topLeftPosition;
    public GameObject bottomRightPosition;
    float xMax;
    float xMin;
    float yMax;
    float yMin;
    public List<GameObject> dinosaurs;
    
    void Start()
    {
        xMax = bottomRightPosition.transform.position.x - 2f;
        xMin = topLeftPosition.transform.position.x + 2f;
        yMax = topLeftPosition.transform.position.y - 2f;
        yMin = bottomRightPosition.transform.position.y + 2f;

        for (int i = 0; i < 5; i++)
        {
            spawnDino();
        }
    }

    public void spawnDino(bool isResurection = false)
    {
        GameObject dino = Instantiate(dinosaurs[Random.Range(0, 4)], getDestinationPosition(), transform.rotation);
        float randomSpeed = Random.Range(4.0f, 8.0f);
        dino.GetComponent<CharacterMovement>().speed = randomSpeed;
        ManagerGame.increaseAmountOfAliveDinos();

        if (isResurection) {
            CollisionDetector collisionDetector = dino.GetComponent<CollisionDetector>();
            if (!collisionDetector) return;

            collisionDetector.isVulnerable = false;
            collisionDetector.enableColliderAfter = Time.time + 1f;
        }
    }

    Vector3 getDestinationPosition()
    {
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        return new Vector3(x, y, 0f);
    }
}
