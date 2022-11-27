using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    static Text scoreText;
    static int currentScore = 0;
    [HideInInspector] public int amountOfAliveDinos;
    static int savedHighScore;
    void Start()
    {
        scoreText = GetComponent<Text>();
        resetScore();
    }

    private void Update()
    {
        scoreText.text = currentScore.ToString();

    }

    public static void increaseScore() {
        currentScore += ManagerGame.Alive;
    }

    public static void saveScore() {
        savedHighScore = PlayerPrefs.GetInt("HighScore");
        if (currentScore > savedHighScore) {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }

    public static void resetScore() {
        currentScore = 0;
        scoreText.text = "0";
    }

    public static int CurrentScore
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
        }
    }

    public static int HightScore
    {
        get
        {
            return savedHighScore;
        }
    }
}
