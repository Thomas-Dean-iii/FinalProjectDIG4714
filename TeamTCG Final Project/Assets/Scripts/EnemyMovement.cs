using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent m_Agent;
    public PlayerHealth playerHealth;

    public float Damage = 15f;
    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();

         if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform; // Store the Transform, not position
            }
            else
            {
                Debug.LogError("Player not found! Make sure it has the 'Player' tag.");
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Agent.destination = player.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(Damage);
        }
    }
}
