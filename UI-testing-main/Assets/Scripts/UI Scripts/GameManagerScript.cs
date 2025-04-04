using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
   
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

}
