using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    static int numberAlive;
    public GameObject overScreen;
    public Button restartButton;
    public Button menuButton;
    public GameObject score;
    public AudioSource gameOverSound;
    HealthCounterBehaviour healthCounter;

    private void Start()
    {
        restartButton.onClick.AddListener(Restart);
        menuButton.onClick.AddListener(ReturnToMenu);

        healthCounter = FindObjectOfType<HealthCounterBehaviour>();
    }

    private void Update()
    {
        if (
            numberAlive <= 0 && 
            !overScreen.activeInHierarchy
        ) {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverSound.Play();
        score.SetActive(false);
        overScreen.SetActive(true);
        ScoreCounter.saveScore();
        FindObjectOfType<HighScoreText>().gameObject.SetActive(true);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("StartingMenu");
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void reduceAmountOfAliveDinos() {
        Alive--;
    }

    public static void increaseAmountOfAliveDinos() {
        Alive++;
    }

    public static int Alive
    {
        get
        {
            return numberAlive;
        }
        set
        {
            numberAlive = value;
        }
    }
}
