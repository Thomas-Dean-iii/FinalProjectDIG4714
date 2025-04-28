using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : MonoBehaviour, ICollectible
{
    public int experienceGranted = 10;

    public delegate void OnCollectibleCollected(int exp);
    public static event OnCollectibleCollected OnCollectibleCollectedEvent;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>(); 
        player.IncreaseExperience(experienceGranted);

        OnCollectibleCollectedEvent?.Invoke(experienceGranted);
        Destroy(gameObject);
    }
}
