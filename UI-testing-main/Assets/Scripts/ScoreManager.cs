using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
     public Text scoreText;
    public Text highscoreText;
    private float timer;

    int score = 0;
    int highscore = 0;
    void Start()
    {
        scoreText.text = score.ToString() + "SCORE:";
        highscoreText.text = "HIGH SCORE:" + highscore.ToString();
    }

    void Update()
    {
        timer += Time.deltaTime;
        score = (int)timer; // Update score based on elapsed time

        scoreText.text = "SCORE: " + score.ToString();

        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = "HIGH SCORE: " + highscore.ToString();

            PlayerPrefs.SetInt("HighScore", highscore);
            PlayerPrefs.Save();
        }
    }

    void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}

