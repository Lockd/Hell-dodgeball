using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounterBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject heartGameObject;
    [SerializeField] private int initialAmountOfHearts = 5;
    
    void Start()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < initialAmountOfHearts; i++) addHeart();
    }

    void Update()
    {
        if (transform.childCount > ManagerGame.Alive)
        {
            for (int i = 0; i < transform.childCount - ManagerGame.Alive; i++)
            {
                removeHeart();
            }
        }
        if (ManagerGame.Alive > transform.childCount)
        {
            for (int j = 0; j < ManagerGame.Alive - transform.childCount; j++)
            {
                addHeart();
            }
        }
    }

    void addHeart()
    {
        Debug.Log("add heart is called");
        GameObject heart = Instantiate(heartGameObject, new Vector3(), Quaternion.identity);
        heart.transform.SetParent(gameObject.transform);
        heart.transform.localScale = new Vector3(20f, 20f, 1f);
    }

    void removeHeart()
    {
        Debug.Log("remove heart is called");
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
