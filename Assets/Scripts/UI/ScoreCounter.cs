using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    static Text scoreText;
    static int currentScore = 0;
    [HideInInspector] public int amountOfAliveDinos;
    void Start()
    {
        scoreText = GetComponent<Text>();
        resetScore();
        Debug.Log("Highest score yet: " + PlayerPrefs.GetInt("HighScore"));
    }

    public static void increaseScore() {
        currentScore += ManagerGame.Alive;
        scoreText.text = currentScore.ToString();
    }

    public static void saveScore() {
        int savedHighScore = PlayerPrefs.GetInt("HighScore");
        Debug.Log("saved high score: " + savedHighScore);
        if (currentScore > savedHighScore) {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }

    public static void resetScore() {
        currentScore = 0;
        scoreText.text = "0";
    }
}
