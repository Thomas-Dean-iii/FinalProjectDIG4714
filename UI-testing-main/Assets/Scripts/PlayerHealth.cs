using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 0f;

    public Image healthBar;
    public GameObject playerOBJ;

    private bool isDead;

    public GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        TakeDamage(10f);
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void Death()
    {
        if(currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            
        }
    }
}
