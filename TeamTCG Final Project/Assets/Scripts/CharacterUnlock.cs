using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterUnlock : MonoBehaviour, IDataPersistence
{
    public static CharacterUnlock instance {get; private set; }
    public Button[] unlockButtons;
    public PlayerStats playerStats;
    int characterAt;

    public GameObject rButton1;
    public GameObject rButton2;
    public GameObject rButton3; 

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

        Rereference();


        
    }

    void Update()
{
    if (playerStats == null)
    {
        playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats == null) return;  // Still null? Don't continue.
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        // Re-reference your buttons here after the scene loads
        Rereference();
    }

    SceneManager.sceneLoaded += OnSceneLoaded; // maybe

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

    public void Rereference()
    {
        rButton1 = GameObject.Find("SelectClown");
        rButton2 = GameObject.Find("SelectPrincess");
        rButton3 = GameObject.Find("SelectMagician");

        // Reassign the buttons to unlockButtons array (assuming it's sized properly)
        if (unlockButtons == null || unlockButtons.Length < 3)
        {
            unlockButtons = new Button[3]; // Ensure enough space
        }

        if (rButton1 != null) unlockButtons[0] = rButton1.GetComponent<Button>();
        if (rButton2 != null) unlockButtons[1] = rButton2.GetComponent<Button>();
        if (rButton3 != null) unlockButtons[2] = rButton3.GetComponent<Button>();

        // Update buttons visibility (this is just an example)
        UpdateUnlocks();
    }
}
