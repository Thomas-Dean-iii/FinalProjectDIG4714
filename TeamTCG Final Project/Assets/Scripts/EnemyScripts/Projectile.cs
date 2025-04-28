using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform player;
    public PlayerHealth playerHealth;
    public float damage = 15f;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Try to damage the player (works with either PlayerHealth or PlayerStats)
            PlayerStats stats = other.gameObject.GetComponent<PlayerStats>();
            if (stats != null)
            {
                stats.TakeDamage(damage);
                Destroy(gameObject);
            }
            else if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

}
