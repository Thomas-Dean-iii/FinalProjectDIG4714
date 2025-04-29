using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    public Transform player; // Assign in Inspector (or auto-find via tag)
    public PlayerHealth playerHealth; // Optional: For direct damage (if not using PlayerStats)

    [Header("Settings")]
    public float damage = 15f;

    private NavMeshAgent m_Agent;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        FindPlayer(); // Initial attempt to find player
    }

    void Update()
    {
        // Only move if player exists
        if (player != null)
        {
            m_Agent.destination = player.position;
        }
        else
        {
            // Retry finding player (e.g., if player respawns)
            FindPlayer();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Try to damage the player (works with either PlayerHealth or PlayerStats)
            PlayerStats stats = collision.gameObject.GetComponent<PlayerStats>();
            if (stats != null)
            {
                stats.TakeDamage(damage);
            }
            else if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    // Helper method to find player by tag
    private void FindPlayer()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
               // Debug.LogWarning("Player not found! Ensure GameObject has 'Player' tag.", this);
            }
        }
    }



}