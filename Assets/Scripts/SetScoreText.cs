using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScoreText : MonoBehaviour
{
    List<int> scores;
    public int scoreType;
    public TextMeshProUGUI text;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Start()
    {
        if (ScoreCounter.CurrentScore > ScoreCounter.HightScore)
        {
            scores = new List<int>()
            {
            ScoreCounter.CurrentScore,
            ScoreCounter.CurrentScore

            };
        }
        else
        {
            scores = new List<int>()
            {
            ScoreCounter.CurrentScore,
            ScoreCounter.HightScore
            };
        }
    }
    void Update()
    {
        text.text = "" + scores[scoreType];
    }
}
