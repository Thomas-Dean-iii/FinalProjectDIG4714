using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    
    [SerializeField] private GameObject levelUpScreen; // Reference to the level-up screen GameObject

    
    public void BoostIcon()
    {
        
        if (levelUpScreen != null)
        {
            levelUpScreen.SetActive(false);
        }

         Time.timeScale = 1f; // Resume the game by setting time scale to 1
    }
}
