using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(NewScene);
    }

    void NewScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
