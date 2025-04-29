using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUnlock : MonoBehaviour, IDataPersistence
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

    public void LoadData(GameData data)
    {
        this.characterAt = data.playersUnlocked; // Load the number of players unlocked
    }

    public void SaveData(ref GameData data)
    {
        data.playersUnlocked = this.characterAt; // Save the number of players unlocked
    }

    void Start()
    {
       // FullReset(); Run when you want to reset all prefs

      // Optionally reset player level when starting a new playthrough
      //  PlayerPrefs.DeleteKey("playerLevel");  // This will reset the player level but keep the character unlocks
        
        // Load character unlock progress from PlayerPrefs
        characterAt = PlayerPrefs.GetInt("characterAt", 0);  // This will preserve the unlocked characters

        // Optionally, you can also reset other stats if needed (such as experience or XP)
        PlayerPrefs.DeleteKey("playerXP"); // Uncomment if you want to reset XP as well

        // Ensure PlayerStats is assigned

        // Update unlock buttons based on saved progress
        UpdateUnlocks();
        
    }

    void Update()
{
    if (playerStats == null)
    {
        playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats == null) return;  // Still null? Don't continue.
    }

    int xp = playerStats.level;
    //Debug.Log("Player Level: " + xp);

    // Unlock character 1 when reaching level 10
    if (xp >= 10 && characterAt < 1)
    {
        characterAt = 1;
        PlayerPrefs.SetInt("characterAt", characterAt);
        PlayerPrefs.Save();
        Debug.Log("Character 1 unlocked");
        UpdateUnlocks();  // Only update unlocks after a change
    }

    // Unlock character 2 when reaching level 20
    else if (xp >= 20 && characterAt < 2)
    {
        characterAt = 2;
        PlayerPrefs.SetInt("characterAt", characterAt);
        PlayerPrefs.Save();
        Debug.Log("Character 2 unlocked");
        UpdateUnlocks();  // Only update unlocks after a change
    }
}

    void UpdateUnlocks()
    {
        // Update buttons based on unlocked characters
        for (int i = 0; i < unlockButtons.Length; i++)
        {
            unlockButtons[i].gameObject.SetActive(i <= characterAt);  // Show unlockable characters
        }
        
    }

    public void FullReset()
    {
        characterAt = 0;
        PlayerPrefs.SetInt("characterAt", characterAt);

        PlayerPrefs.SetInt("playerLevel", 0);   // Reset player level
        PlayerPrefs.SetInt("playerXP", 0);       // Reset player XP if you track it separately

        PlayerPrefs.Save();
        UpdateUnlocks();
    }
}
