using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    public AudioMixer masterMixer;

    

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        masterMixer.SetFloat("MasterVol", PrefrencesManager.GetMasterVolume());
        masterMixer.SetFloat("MusicVol", PrefrencesManager.GetMusicVolume());

        
    }

    public void ChangeSoundVolume(float soundlevel)
    {
        masterMixer.SetFloat("MasterVol", soundlevel);
        PrefrencesManager.SetMasterVolume(soundlevel);
    }

    public void ChangeMusicVolume(float soundlevel)
    {
        masterMixer.SetFloat("MusicVol", soundlevel);
        PrefrencesManager.SetMusicVolume(soundlevel);
    }
}
