using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inimigo : MonoBehaviour
{
    public int vida = 100;
    public BossVida bossVida;
    [SerializeField] private GameObject telaMorteBoss;
    [SerializeField] private PopupDano popup;

    void Start()
    {
        bossVida.DefinirVidaMax(vida);
    }

    
    void Update()
    {
        
    }

    public void LevarDano(int dano)
    {
        vida -= dano;
        popup.Criar(transform.position, dano);
        bossVida.DefinirVida(vida);
        if(vida <= 0)
        {
            Morto();
        }
    }

    public void Morto()
    {
        telaMorteBoss.SetActive(true);
        Time.timeScale = 0;
    }
}
