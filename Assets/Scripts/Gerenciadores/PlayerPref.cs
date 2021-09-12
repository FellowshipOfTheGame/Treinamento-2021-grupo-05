using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    const string MUSIC_VOLUME_KEY = "music volume";
    const string SFX_VOLUME_KEY = "SFX volume";
    const string FULL_SCREEN = "full screen mode";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    public static void SetMusicVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Music volume set to " + volume);
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Music Volume is out of Range");
        }
    }

    public static void SetScreenMode(bool mode)
    {
        if(mode)
        {
            PlayerPrefs.SetInt(FULL_SCREEN, 1);
        }
        else
        {
            PlayerPrefs.SetInt(FULL_SCREEN, 0);
        }
        
    }

    public static bool GetScreenMode()
    {
        if (PlayerPrefs.GetInt(FULL_SCREEN, 1) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1f);
    }

    public static void SetSFXVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("SFX volume set to " + volume);
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("SFX Volume is out of Range");
        }
    }

    public static float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1f);
    }
}
