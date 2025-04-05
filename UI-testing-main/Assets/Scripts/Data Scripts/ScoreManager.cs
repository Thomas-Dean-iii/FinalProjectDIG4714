using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml.Serialization;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text finalScoreText;
    public Text highscoreText;
    private float timer;


    int score = 0;
    int highscore = 0;

    [System.Serializable]
    public class HighScoreData
    {
        public int highscore;
    }


    void Start()
    {
        LoadHighScore();
        scoreText.text = score.ToString() + "SCORE:";
        highscoreText.text = "HIGH SCORE:" + highscore.ToString();
    }

    void Update()
    {
        timer += Time.deltaTime;
        score = (int)timer; 

        scoreText.text = "SCORE: " + score.ToString();

        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = "HIGH SCORE: " + highscore.ToString();
            SaveHighScore();
        }
    }

    public void HighScoreUpdate()
    {
        finalScoreText.text = "FINAL SCORE: " + score.ToString();
        highscoreText.text = "HIGH SCORE: " + highscore.ToString();

        if (PlayerPrefs.HasKey("SavedHighScore"))
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

    public void SaveHighScore()
    {
        HighScoreData data = new HighScoreData();
        data.highscore = highscore;

        XmlSerializer seriallizer = new XmlSerializer(typeof(HighScoreData));
        using (FileStream stream = new FileStream(Application.persistentDataPath + "/highscore.xml", FileMode.Create))
        {
            seriallizer.Serialize(stream, data);
        }
    }

    void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.xml";
        if (File.Exists(path))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HighScoreData));
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                HighScoreData data = (HighScoreData)serializer.Deserialize(stream);
                highscore = data.highscore;
            }
        }
    }

    public void ResetHighScore()
    {
        highscore = 0;
        SaveHighScore();
        highscoreText.text = "HIGH SCORE: " + highscore.ToString();
    }

    void OnApplicationQuit()
    {
        SaveHighScore();
    }

}

