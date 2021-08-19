using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField] private GameObject telaMorte;

    [SerializeField] private Image atual;
    [SerializeField] private float vidaTotal;
    private float vidaAtual;

    [SerializeField] private float iFrame;
    private float invencibilidade;

    private bool morto;

    private void Awake()
    {
        atual.fillAmount = 1;
        vidaAtual = vidaTotal;
    }

    // Update is called once per frame
    void Update()
    {
        atual.fillAmount = vidaAtual / vidaTotal;

        invencibilidade += Time.deltaTime;
    }

    public void Dano(float _dano)
    {
        if(invencibilidade>iFrame)
        {
            vidaAtual = Mathf.Clamp(vidaAtual - _dano, 0, vidaTotal);
            invencibilidade = 0f;
        }

        if(vidaAtual <= 0 && !morto)
        {
            telaMorte.SetActive(true);
            Time.timeScale = 0;
            morto = true;
        }
    }
}