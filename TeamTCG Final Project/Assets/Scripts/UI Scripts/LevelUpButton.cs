using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    
    [SerializeField] private GameObject levelUpScreen; // Reference to the level-up screen GameObject

    public PlayerAbilities Player;

    private int BalloonLevel;
    private int CakeLevel;
    private int WaterGunLevel;
    /*public void BoostIcon()
    {
        Player = FindObjectOfType<PlayerAbilities>();
        if (levelUpScreen != null)
        {
            levelUpScreen.SetActive(false);
        }

         Time.timeScale = 1f; // Resume the game by setting time scale to 1
    }*/

    public void BalloonIcon()
    {
        Player = FindObjectOfType<PlayerAbilities>();
        BalloonLevel = Player.abilityOneLevel;
        if (BalloonLevel >= 3)
        {
            gameObject.SetActive(false);
        }
        else
        {
            BalloonLevel++;
            Player.abilityOneLevel = BalloonLevel;
        }
    }
    public void CakeIcon()
    {
        Player = FindObjectOfType<PlayerAbilities>();
        CakeLevel = Player.abilityTwoLevel;
        if (CakeLevel >= 3)
        {
            gameObject.SetActive(false);
        }
        else
        {
            CakeLevel++;
            Player.abilityTwoLevel = CakeLevel;
        }
    }
    public void WatgerGunIcon()
    {
        Player = FindObjectOfType<PlayerAbilities>();
        WaterGunLevel = Player.abilityThreeLevel;
        if (WaterGunLevel >= 3)
        {
            gameObject.SetActive(false);
        }
        else 
        {
            WaterGunLevel++;
            Player.abilityThreeLevel = WaterGunLevel;
        }
    }
}

