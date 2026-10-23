using CitrioN.Common;
using System.Collections.Frozen;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;


//using unity discussions post with edits
public class pause: MonoBehaviour
{
   [Header("Set Up")]
    public GameObject pausemenu;
    public UnityEngine.UI.Slider musicSlider;
    public UnityEngine.UI.Slider sfxSlider;

    public AudioMixer audioMixer;


    //set up pllayerpref keys 
    private const string MusicKey = "MusicVolume";
    private const string SFXKey = "SFXVolume";
    private bool paused;

    private void Start()
    {
        pausemenu.SetActive(false);
        float music = PlayerPrefs.GetFloat(MusicKey);
        float sfx = PlayerPrefs.GetFloat(SFXKey);

        // Set sliders

        musicSlider.value = music;
        sfxSlider.value = sfx;

        // Apply to mixer

        SetMusicVolume(music);
        SetSFXVolume(sfx);

        // Add listeners

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                pausemenu.SetActive(true);
                paused = true;
                PauseGame();
            }
            else
            {
                pausemenu.SetActive(false);
                paused = false;
                
                ResumeGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

    }
    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat(MusicKey, value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat(SFXKey, value);
        PlayerPrefs.Save();
    }









}
