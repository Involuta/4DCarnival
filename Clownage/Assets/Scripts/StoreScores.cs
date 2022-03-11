using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreScores : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Scores.yourScore = 0;
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Clowns Eliminated: {Scores.yourScore}";
    }
}

public static class Scores
{
    public static int yourScore { get; set; }
    public static int highScore { get; set; }
}