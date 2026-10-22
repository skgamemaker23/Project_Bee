using UnityEngine;
using UnityEngine.Audio;

public class pausemenu : MonoBehaviour
{
    [Header("UI Sliders")]

    public UnityEngine.UI.Slider musicSlider;
    public UnityEngine.UI.Slider sfxSlider;



    [Header("Settings")]
    public AudioMixer audioMixer;

    private const string MusicKey = "MusicVolume";
    private const string SFXKey = "SFXVolume";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
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
