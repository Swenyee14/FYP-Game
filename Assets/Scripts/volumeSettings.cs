using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider slider;
    [SerializeField] private Slider sliderSFX;

    private void Start()
    {
        if (PlayerPrefs.HasKey("setMusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            MusicVolume();
            SFXVolume();
        }
    }

    public void MusicVolume()
    {
        float volume = slider.value;
        mixer.SetFloat("forMusic", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("setMusicVolume", volume);
    }

    public void SFXVolume()
    {
        float volume = sliderSFX.value;
        mixer.SetFloat("forSFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("setSFXVolume", volume);
    }

    private void LoadVolume()
    {
        slider.value = PlayerPrefs.GetFloat("setMusicVolume");
        sliderSFX.value = PlayerPrefs.GetFloat("setSFXVolume");
        MusicVolume();
        SFXVolume();
    }
}


