using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// Handles audio settings menu with PlayerPrefs persistence.
/// Attach this script to a GameObject in your settings UI.
/// </summary>
public class SettingsMenu : MonoBehaviour
{
    [Header("UI Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Audio Mixer")]
    public AudioMixer audioMixer; // Assign your AudioMixer in Inspector

    // PlayerPrefs keys
    private const string MasterKey = "MasterVolume";
    private const string MusicKey = "MusicVolume";
    private const string SFXKey = "SFXVolume";

    private void Start()
    {
        // Load saved values or defaults
        float master = PlayerPrefs.GetFloat(MasterKey, 0.75f);
        float music = PlayerPrefs.GetFloat(MusicKey, 0.75f);
        float sfx = PlayerPrefs.GetFloat(SFXKey, 0.75f);

        // Set sliders
        masterSlider.value = master;
        musicSlider.value = music;
        sfxSlider.value = sfx;

        // Apply to mixer
        SetMasterVolume(master);
        SetMusicVolume(music);
        SetSFXVolume(sfx);

        // Add listeners
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMasterVolume(float value)
    {
        // AudioMixer expects dB, convert from 0-1 slider
        audioMixer.SetFloat("MasterVol", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat(MasterKey, value);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVol", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat(MusicKey, value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVol", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat(SFXKey, value);
        PlayerPrefs.Save();
    }
}
