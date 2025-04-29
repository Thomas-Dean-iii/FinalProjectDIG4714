using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpManager : MonoBehaviour, IDataPersistence
{
    public int level;
    public int currentExp;
    public int expToLevel = 300; // exp needed to level up
    public float expMultiplier = 1.4f; // multiplier for exp, adds 20% more exp each level
    public Slider expSlider; // UI slider to show exp progress
    public TMP_Text currentLevelText;
    public TMP_Text resultsLevelText;


    public void LoadData(GameData data)
    {
        this.level = data.level;
    }

    public void SaveData(ref GameData data)
    {
        data.level = this.level;
    }



    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // for testing purposes
        {
            GainExperience(10); // gain 10 exp when E is pressed
        }
    }

    private void OnEnable()
    {
        ExperienceGem.OnCollectibleCollectedEvent += GainExperience;
    }
    private void OnDisable()
    {
        ExperienceGem.OnCollectibleCollectedEvent -= GainExperience;
    }

    public void GainExperience(int amount)
    {
        currentExp += amount;
        if (currentExp >= expToLevel)
        {
            LevelUp();
        }
        UpdateUI();
    }

    private void LevelUp()
    {
        level++;
        currentExp -= expToLevel; // makes the leftover exp available for the next level
        expToLevel = Mathf.RoundToInt(expToLevel * expMultiplier);

        // UiController.instance.levelUpScreen.SetActive(true); // Show level up screen

        //Time.timeScale = 0f; // pauses the game
    }

    public void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level: " + level;
        resultsLevelText.text = "Level: " + level; // Update the level text in the results screen
    }
}