using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer masterMixer;

    public Slider musicSlider, masterSlider;

    void Start()
    {
        masterMixer.SetFloat("MasterVol", PrefrencesManager.GetMasterVolume());
        masterMixer.SetFloat("MusicVol", PrefrencesManager.GetMusicVolume());

        if (masterSlider != null)
            masterSlider.value = PrefrencesManager.GetMasterVolume();

        if (musicSlider != null)
            musicSlider.value = PrefrencesManager.GetMusicVolume();
    }
    public void ChangeSoundVolume(float soundlevel)
    {
        AudioManager.Instance.ChangeSoundVolume(soundlevel);
    }

    public void ChangeMusicVolume(float soundlevel)
    {
        AudioManager.Instance.ChangeMusicVolume(soundlevel);
    }
}
