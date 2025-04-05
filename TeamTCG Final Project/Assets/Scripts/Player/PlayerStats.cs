using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    void Awake()
    {
        currentHealth = charaterData.MaxHealth;
        currentRecovery = charaterData.Recovery;
        currentMoveSpeed = charaterData.MoveSpeed;
        currentMight = charaterData.Might;
        currentProjectileSpeed = charaterData.ProjectileSpeed;
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
}
