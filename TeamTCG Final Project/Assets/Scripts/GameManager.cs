using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerStats>().OnPlayerDeath += PlayerDeath;
    }

    void PlayerDeath()
    {
        Debug.Log("Game Over");
    }

    private void Disable()
    {
        FindObjectOfType<PlayerStats>().OnPlayerDeath -= PlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
