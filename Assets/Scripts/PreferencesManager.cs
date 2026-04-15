using UnityEngine;

public static class PrefrencesManager
{
    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("MusicVolume", 1f);
    }


    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat("MasterVolume", 1f);
    }

    public static void SetMusicVolume(float soundlevel)
    {
        PlayerPrefs.SetFloat("MusicVolume", soundlevel);
    }

    public static void SetMasterVolume(float soundlevel)
    {
        PlayerPrefs.SetFloat("MasterVolume", soundlevel);
    }
}
