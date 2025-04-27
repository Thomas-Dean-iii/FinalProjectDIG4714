using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUnlock : MonoBehaviour
{
    public static CharacterUnlock instance {get; private set; }
    public Button[] unlockButtons;
    public PlayerStats playerStats;
    int characterAt;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // Optionally reset player level when starting a new playthrough
        PlayerPrefs.DeleteKey("playerLevel");  // This will reset the player level but keep the character unlocks
        
        // Load character unlock progress from PlayerPrefs
        characterAt = PlayerPrefs.GetInt("characterAt", 0);  // This will preserve the unlocked characters

        // Optionally, you can also reset other stats if needed (such as experience or XP)
        // PlayerPrefs.DeleteKey("playerXP"); // Uncomment if you want to reset XP as well

        // Ensure PlayerStats is assigned
        if (playerStats == null)
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }

        // Update unlock buttons based on saved progress
        UpdateUnlocks();
    }

    void Update()
    {
        if (playerStats == null) return;
        playerStats = FindObjectOfType<PlayerStats>();

        int xp = playerStats.level;
        Debug.Log("Player Level: " + xp);

        // Unlock character 1 when reaching level 10
        if (xp >= 10 && characterAt < 1)
        {
            characterAt = 1;
            PlayerPrefs.SetInt("characterAt", characterAt);  // Save unlocked characters
            PlayerPrefs.Save();
            Debug.Log("Character 1 unlocked");
        }

        // Unlock character 2 when reaching level 20
        if (xp >= 20 && characterAt < 2)
        {
            characterAt = 2;
            PlayerPrefs.SetInt("characterAt", characterAt);  // Save unlocked characters
            PlayerPrefs.Save();
            Debug.Log("Character 2 unlocked");
        }

        UpdateUnlocks();
    }

    void UpdateUnlocks()
    {
        // Update buttons based on unlocked characters
        for (int i = 0; i < unlockButtons.Length; i++)
        {
            unlockButtons[i].gameObject.SetActive(i <= characterAt);  // Show unlockable characters
        }
    }
}
