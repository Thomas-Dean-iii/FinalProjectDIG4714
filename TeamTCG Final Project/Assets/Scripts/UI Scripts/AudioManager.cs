using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource;

    [SerializeField] Slider volumeSlider;

    [Header("Background Music")]
    [SerializeField] private AudioClip[] backgroundMusic;


    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusic(0);

        if(PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }


    }

    public void ChangeVolume()
    {
        musicSource.volume = volumeSlider.value;
        Save();
    }

    public void BackgroundMusic(int sceneNumber)
    {
        musicSource.clip = backgroundMusic[sceneNumber];
        musicSource.Play();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Volume", musicSource.volume);
    }

}
