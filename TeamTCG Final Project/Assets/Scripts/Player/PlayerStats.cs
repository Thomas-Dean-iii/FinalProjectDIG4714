using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject charaterData;

   public float currentHealth;
    float currentRecovery;
    float currentMoveSpeed;
    float currentMight;
    float currentProjectileSpeed;

    // Experience and Level of the player
    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap = 100;
    public int experienceCapIncrease;

    //I-Frames
    [Header("I-Frames")]
    public float iFrameDuration;
    private float iFrameTimer;
    private bool isInvincible;

    [Header("Health bar")]
    public Image healthBar;

    void Awake()
    {
        currentHealth = charaterData.MaxHealth;
        currentRecovery = charaterData.Recovery;
        currentMoveSpeed = charaterData.MoveSpeed;
        currentMight = charaterData.Might;
        currentProjectileSpeed = charaterData.ProjectileSpeed;

        level = PlayerPrefs.GetInt("playerLevel", 1);
    }

    void Update()
    {
        if(iFrameTimer > 0)
        {
            iFrameTimer -= Time.deltaTime;
        }
        else if(isInvincible)
        {
            isInvincible = false;
        }
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevelUpChecker();
        
    }

    void LevelUpChecker()
    {
        if(experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;
            experienceCap += experienceCapIncrease;

            PlayerPrefs.SetInt("playerLevel", level);  // Save level progress
            PlayerPrefs.Save();
        }
    }

    public void TakeDamage(float dmg)
    {
        if(!isInvincible)
        {
            currentHealth -= dmg;
            healthBar.fillAmount = currentHealth / charaterData.MaxHealth;

            iFrameTimer = iFrameDuration;
            isInvincible = true;

            if(currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Debug.Log("Player IS DEAD");
    }
}
