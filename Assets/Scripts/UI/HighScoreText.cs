using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    [SerializeField] private Vector3 maxScale = new Vector3(1.2f, 1.2f, 1f);
    [SerializeField] private float growthSpeed = 1f;
    Vector3 initialScale;
    bool isGrowing = true;

    void Start()
    {
        initialScale = transform.localScale;
        int HighScore = PlayerPrefs.GetInt("HighScore");
        if (ScoreCounter.CurrentScore < HighScore) {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        float scaleValue = Time.deltaTime * growthSpeed;
        if (!isGrowing) scaleValue = scaleValue * -1;

        transform.localScale = transform.localScale + new Vector3(scaleValue, scaleValue, 0f);

        if (transform.localScale.x > maxScale.x) isGrowing = false;
        if (transform.localScale.x < initialScale.x) isGrowing = true;
    }
}
