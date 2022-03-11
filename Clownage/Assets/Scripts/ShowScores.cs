using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScores : MonoBehaviour
{
    public TextMeshProUGUI yourScoreText;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        yourScoreText = GameObject.Find("YourScore").GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        highScoreText.text = $"High Score: {Scores.highScore}";
        yourScoreText.text = $"Your Score: {Scores.yourScore}";
    }
}