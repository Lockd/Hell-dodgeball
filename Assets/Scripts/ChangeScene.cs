using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public Button button;
    void Start()
    {
        button.onClick.AddListener(NewScene);
    }

    void NewScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
