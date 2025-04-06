using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject charaterData;

    float currentHealth;
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
   //public GameObject playerOBJ;



    void Awake()
    {
        currentHealth = charaterData.MaxHealth;
        currentRecovery = charaterData.Recovery;
        currentMoveSpeed = charaterData.MoveSpeed;
        currentMight = charaterData.Might;
        currentProjectileSpeed = charaterData.ProjectileSpeed;
    }

     void Update()
    {
        if(iFrameTimer > 0)
        {
            iFrameTimer -= Time.deltaTime;
        }
        //If the Invinciblity timer reaches 0 , set invinsiblity bool to false
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
        if(experience >= experienceCap)//Increase level if the experience is more than or equal to the required amount to level up
        {
            //Level up the player and deduct their experience
            level++;
            experience -= experienceCap;
            experienceCap += experienceCapIncrease;
        }
    }

    public void TakeDamage(float dmg)
    {
        //if player isnt invincible
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
