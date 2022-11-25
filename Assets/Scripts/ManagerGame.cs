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

    private void Start()
    {
        restartButton.onClick.AddListener(Restart);
    }

    private void Update()
    {
        if (numberAlive <= 0) GameOver();
    }

    void GameOver()
    {
        overScreen.SetActive(true);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("StartingMenu");
    }

    void Restart()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
