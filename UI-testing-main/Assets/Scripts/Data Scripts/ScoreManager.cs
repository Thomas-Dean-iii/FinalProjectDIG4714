using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text finalScoreText;
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

    public void HighScoreUpdate()
    {
        if(PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (score > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", score);
              
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
        }

        finalScoreText.text = "FINAL SCORE: " + score.ToString();
        highscoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

}

