using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    [SerializeField] private Toggle marcador;
    public bool fullScreen;

    private void Start()
    {
        fullScreen = PlayerPref.GetScreenMode();
        Screen.fullScreen = fullScreen;
        marcador.isOn = fullScreen;
    }
    public void ChangeScreenMode()
    {
        fullScreen = !fullScreen;
        PlayerPref.SetScreenMode(fullScreen);
        Screen.fullScreen = fullScreen;
    }

    private void Awake()
    {
        
    }
}
