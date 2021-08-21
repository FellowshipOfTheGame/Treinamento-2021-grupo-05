using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField] private GameObject telaMorte;
    [SerializeField] private BarraVida barraVida;
    [SerializeField] private float vidaTotal;
    private float vidaAtual;

    [SerializeField] private float iFrame;
    private float invencibilidade;

    private bool morto;

    private void Awake()
    {
        vidaAtual = vidaTotal;
        barraVida.DefinirVidaMax((int)vidaTotal);
    }

    // Update is called once per frame
    void Update()
    {
        invencibilidade += Time.deltaTime;
    }

    public void Dano(float _dano)
    {
        if(invencibilidade>iFrame)
        {
            vidaAtual -= _dano;
            barraVida.DefinirVida((int)vidaAtual);
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
