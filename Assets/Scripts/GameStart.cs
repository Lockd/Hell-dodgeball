using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject topLeftPosition;
    public GameObject bottomRightPosition;
    float xMax;
    float xMin;
    float yMax;
    float yMin;
    public List<GameObject> dinosaurs;
    // Start is called before the first frame update
    void Start()
    {
        xMax = bottomRightPosition.transform.position.x - 2f;
        xMin = topLeftPosition.transform.position.x + 2f;
        yMax = topLeftPosition.transform.position.y - 2f;
        yMin = bottomRightPosition.transform.position.y + 2f;
        for (int i = 0; i<5; i++)
        {
            GameObject dino = Instantiate(dinosaurs[Random.Range(0, 3)], getDestinationPosition(), transform.rotation);
            dino.GetComponent<CharacterMovement>().speed = Random.Range(4, 8);
            ManagerGame.Alive++;
        }
    }

    Vector3 getDestinationPosition()
    {
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        return new Vector3(x, y, 0f);
    }
}