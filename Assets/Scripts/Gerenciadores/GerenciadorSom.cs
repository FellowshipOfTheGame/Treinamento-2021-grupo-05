using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorSom : MonoBehaviour
{
    public static GerenciadorSom instancia;

    private float musicaVolume = 1f;
    private float SFXVolume = 1f;

    private AudioClip creditos, menu, botao, erro, lose, boss1, boss2, boss3, gameoover, bossmorto; // musicas
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
        boss1 = Resources.Load<AudioClip>("Boss trilha 1");
        boss2 = Resources.Load<AudioClip>("Boss trilha 2");
        boss3 = Resources.Load<AudioClip>("Boss trilha 3");
        erro = Resources.Load<AudioClip>("Erro");
        lose = Resources.Load<AudioClip>("You Lose");
        gameoover = Resources.Load<AudioClip>("BOSS");
        bossmorto = Resources.Load<AudioClip>("Bossmorrendo");


        audioSource.volume = musicaVolume;
    }

    public void TocarEfeito(string efeito)
    {

        switch (efeito)
        {
            case "botao":
                audioSource.PlayOneShot(botao, SFXVolume);
                break;
            case "erro":
                audioSource.PlayOneShot(erro, SFXVolume);
                break;
            case "lose":
                audioSource.PlayOneShot(lose, SFXVolume);
                break;
            case "bossmorto":
                audioSource.PlayOneShot(bossmorto, SFXVolume);
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
            case "lose":
                audioSource.clip = gameoover;
                audioSource.Play();
                break;
            default:
                break;
        }
    }

    public void Stop()
    {
        audioSource.Stop();
    }
    public void TrocarMusicaBoss(string musica)
    {
        float tempo = audioSource.time;
        switch (musica)
        {
            case "boss1":
                audioSource.clip = boss1;
                audioSource.time = Mathf.Min(tempo, boss1.length - 1f);
                audioSource.Play();
                break;
            case "boss2":
                audioSource.clip = boss2;
                audioSource.time = Mathf.Min(tempo, boss2.length - 1f);
                audioSource.Play();
                break;
            case "boss3":
                audioSource.clip = boss3;
                audioSource.time = Mathf.Min(tempo, boss3.length - 1f);
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
