using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    [SerializeField] private Toggle marcador;
    [SerializeField] private bool fullScreen;


    private void Start()
    {
        fullScreen = PlayerPref.GetScreenMode();
        ChangeScreenMode(fullScreen);
        marcador.isOn = fullScreen;
    }
    public void ChangeScreenMode(bool mode)
    {
        fullScreen = mode;
        PlayerPref.SetScreenMode(fullScreen);
        if (fullScreen)
        {
            Screen.SetResolution(1920, 1080, fullScreen);
        }
        else
        {
            Screen.SetResolution(1040, 585, fullScreen);
        }
        
    }
}
