using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject winScreenUI;

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void winGame()
    {
        winScreenUI.SetActive(true);
        Time.timeScale = 0;
    }

}
