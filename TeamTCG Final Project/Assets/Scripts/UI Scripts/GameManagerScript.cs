using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public PlayerStats playerStats;
   
    private void Update()
    {
        if(playerStats == null)
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }
        GameOver();


    }
    public void GameOver()
    {
        if(playerStats.currentHealth <= 0)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
