using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorSom : MonoBehaviour
{
    public static GerenciadorSom instancia;

    private float musicaVolume = 1f;
    private float SFXVolume = 1f;

    private AudioClip creditos, menu, botao; // musicas
    private AudioSource audioSource;
    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        creditos = Resources.Load<AudioClip>("Creditos");
        menu = Resources.Load<AudioClip>("Trilhasonorapause");
        botao = Resources.Load<AudioClip>("04-Som Select, stop, next");

        audioSource.volume = musicaVolume;
    }

    public void TocarEfeito(string efeito)
    {

        switch (efeito)
        {
            case "botao":
                audioSource.PlayOneShot(botao, SFXVolume);
                break;
            default:
                break;
        }


    }

    public void TrocarMusica(string musica)
    {
        switch (musica)
        {
            case "menu":
                audioSource.clip = menu;
                audioSource.Play();
                break;
            case "creditos":
                audioSource.clip = creditos;
                audioSource.Play();
                break;
            default:
                break;
        }
    }

    public void MudarVolumeMusica(float volume)
    {
        audioSource.volume = volume;
        PlayerPref.SetMusicVolume(volume);
    }

    public void MudarVolumeSFX(float volume)
    {
        SFXVolume = volume;
        PlayerPref.SetSFXVolume(volume);

    }
}
