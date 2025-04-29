using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController instance;

    public GameObject winScreenMenu;

    private void Awake()
    {
        instance = this;
    }

    public TMP_Text timerText;
    public GameObject levelUpScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTimer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60f); // 60 seconds in a minute
        float seconds = Mathf.FloorToInt(time % 60f);

        timerText.text = "Time: " + minutes + ":" + seconds.ToString("00");

        if (time >= 300f) // Check if timer has hit 5 minutes, if so show win screen
        {
            ShowWinScreen();
        }
    }

    public void ShowWinScreen()
    {
        if (winScreenMenu != null)
        {
            winScreenMenu.SetActive(true);
        }
    }

}










