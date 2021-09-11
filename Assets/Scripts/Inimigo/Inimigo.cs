using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inimigo : MonoBehaviour
{
    public int vida = 100;
    private int vidaTotal;
    public BossVida bossVida;
    [SerializeField] private GameObject telaMorteBoss;
    [SerializeField] private PopupDano popup;

    public bool Fase2 = false;
    public bool Fase3 = false;

    void Start()
    {
        bossVida.DefinirVidaMax(vida);
        vidaTotal = vida;
    }


    void Update()
    {
        if (vida <= 2 * vidaTotal/3 && !Fase2)
        {
            Fase2 = true;
            GetComponent<Movimento_Inimigo>().Fase2();
        }
        else if (vida <= vidaTotal/3 && !Fase3)
        {
            Fase3 = true;
        }
    }

    public void LevarDano(int dano)
    {
        vida -= dano;
        popup.Criar(transform.position, dano);
        bossVida.DefinirVida(vida);
        if (vida <= 0)
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
