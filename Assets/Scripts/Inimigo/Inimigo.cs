using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inimigo : MonoBehaviour
{
    public int vida;
    public int vidaTotal;
    public BossVida bossVida;
    //[SerializeField] private GameObject telaMorteBoss;
    private GameObject gerenciadorRespawn;
    private Respawn respawnScript;
    public float ataqueOriginal;
    [SerializeField] private Timer timerScript;
    [SerializeField] private Posicao_Tiros posicaoScript;
    [SerializeField] private PopupDano popup;

    public bool Fase1 = false;
    public bool Fase2 = false;
    public bool Fase3 = false;

    void Start()
    {
        gerenciadorRespawn = GameObject.FindGameObjectWithTag("respawn");
        respawnScript = gerenciadorRespawn.GetComponent<Respawn>();
        bossVida.DefinirVidaMax(vida);
        vidaTotal = vida + 10*respawnScript.numInimigosMortos;
    }


    void Update()
    {
        if (vida == vidaTotal && !Fase1)
        {
            Fase1 = true;
            Fase2 = false;
            Fase3 = false;
            respawnScript.bancoVelocidadeTiros = ataqueOriginal + ataqueOriginal * 0.1f * respawnScript.numInimigosMortos;
            posicaoScript.tirosMax = respawnScript.bancoTirosMax + (respawnScript.numInimigosMortos);
            bossVida.DefinirVidaMax(vida);
            bossVida.DefinirVida(vida);
        }
        if (vida <= 2 * vidaTotal/3 && !Fase2)
        {
            Fase2 = true;
            respawnScript.bancoVelocidadeTiros *= 1.1f;
            posicaoScript.tirosMax++;
            GetComponent<Movimento_Inimigo>().Fase2();
        }
        if (vida <= vidaTotal/3 && !Fase3)
        {
            Fase3 = true;
            respawnScript.bancoVelocidadeTiros *= 1.3f;
            posicaoScript.tirosMax++;
            GetComponent<Movimento_Inimigo>().Fase3();
        }
    }

    public void LevarDano(int dano)
    {
        vida -= dano;
        popup.Criar(transform.position, dano);
        bossVida.DefinirVida(vida);
        if (vida <= 0)
        {
            // inserir animacao de morte
            respawnScript.numInimigosMortos++;
            respawnScript.isMorto = true;
            //posicaoScript.tirosMax = respawnScript.bancoTirosMax + (respawnScript.numInimigosMortos);
            Fase1 = false;
            Fase2 = false;
            Fase3 = false;
            timerScript.MorteInimigo();
            gameObject.SetActive(false);
        }
    }

    /*public void Morto()
    {
        telaMorteBoss.SetActive(true);
        Time.timeScale = 0;
    }*/
}
