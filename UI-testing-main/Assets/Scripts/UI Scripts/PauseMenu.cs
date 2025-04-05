using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public ScoreManager scoreManager;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;

        if (scoreManager != null)
        {
            scoreManager.SaveHighScore();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        if (scoreManager != null)
        {
            scoreManager.ResetHighScore();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeTime();
    }

   private void ResumeTime()
    {
        Time.timeScale = 1;
    }
    
}
