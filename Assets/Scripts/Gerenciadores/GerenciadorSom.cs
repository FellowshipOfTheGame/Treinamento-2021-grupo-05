using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorSom : MonoBehaviour
{
    public static GerenciadorSom instancia;

    private float musicaVolume = 1f;
    private float SFXVolume = 1f;

    private AudioClip creditos, menu, botao, boss1, boss2, boss3; // musicas
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
        boss1 = Resources.Load<AudioClip>("Boss trilha 1 150 bpm f� maior");
        boss2 = Resources.Load<AudioClip>("Boss trilha 1 150 bpm f� maior");
        boss3 = Resources.Load<AudioClip>("Boss trilha 1 150 bpm f� maior");

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
            case "boss1":
                audioSource.clip = boss1;
                audioSource.Play();
                break;
            case "boss2":
                audioSource.clip = boss2;
                audioSource.Play();
                break;
            case "boss3":
                audioSource.clip = boss3;
                audioSource.Play();
                break;
            default:
                break;
        }
    }

    public void TrocarMusicaBoss(string musica)
    {
        float tempo = audioSource.time;
        switch (musica)
        {
            case "boss1":
                audioSource.clip = boss1;
                audioSource.time = tempo;
                audioSource.Play();
                break;
            case "boss2":
                audioSource.clip = boss2;
                audioSource.time = tempo;
                audioSource.Play();
                break;
            case "boss3":
                audioSource.clip = boss3;
                audioSource.time = tempo;
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