using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadoMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas = null;
    [SerializeField] private GameObject creditoCanvas = null;
    [SerializeField] private GameObject configuracoesPanel = null;
    [SerializeField] private Slider musicaSlider;
    [SerializeField] private Slider SFXSlider;
    private GerenciadorSom gerenciadorSom;
    void Start()
    {
        gerenciadorSom = GerenciadorSom.instancia;
        musicaSlider.value = PlayerPref.GetMusicVolume();
        SFXSlider.value = PlayerPref.GetSFXVolume();
    }

    private void Update()
    {
        
        
    }
    public void BotaoCredito()
    {
        gerenciadorSom.TocarEfeito("botao");
        gerenciadorSom.TrocarMusica("creditos");
        menuCanvas.SetActive(false);
        creditoCanvas.SetActive(true);
    } 

    public void MudarVolumeMusica()
    {
        gerenciadorSom.MudarVolumeMusica(musicaSlider.value);
    }

    public void MudarVolumeSFX()
    {
        gerenciadorSom.MudarVolumeSFX(SFXSlider.value);
    }

    public void BotaoSairCredito()
    {
        gerenciadorSom.TocarEfeito("botao");
        gerenciadorSom.TrocarMusica("menu");
        menuCanvas.SetActive(true);
        creditoCanvas.SetActive(false);
    }

    public void BotaoConfiguracoes()
    {
        gerenciadorSom.TocarEfeito("botao");
        configuracoesPanel.SetActive(true);
    }

    public void BotaoSairConfiguracoes()
    {
        gerenciadorSom.TocarEfeito("botao");
        configuracoesPanel.SetActive(false);
    }

    public void BotaoSairMenu()
    {
        gerenciadorSom.TocarEfeito("botao");
        Debug.Log("Sair do jogo");
        Application.Quit();
    }

 

}