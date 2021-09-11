using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float TempoPorTurno;
    [SerializeField] private Movimento_Inimigo bossMov;
    private GameObject inimigo;
    [SerializeField] private Posicao_Tiros posicaoTiros;
    [SerializeField] private Laser laser;
    [SerializeField] private Transform player;
    [SerializeField] private Transform boss;
    [SerializeField] private Movimento playerMov;
    [SerializeField] private Rigidbody2D playerRB;
    private Vector3 posicaoOriginalPlayer;
    private Vector3 posicaoOriginalBoss;
    private GameObject typer;
    private float tempoRestante;
    public bool mododeDano = false;

    private void Awake()
    {
        inimigo = GameObject.FindGameObjectWithTag("Inimigo");
        laser = inimigo.GetComponent<Laser>();
    }

    private void Start()
    {
        posicaoOriginalBoss = boss.position;
        
        posicaoOriginalPlayer = player.position;
        tempoRestante = TempoPorTurno;
        
    }
    void Update()
    {
        tempoRestante -= Time.deltaTime;
        if (tempoRestante <= 0)
        {
            tempoRestante = TempoPorTurno;
            if (mododeDano)
            {
                mododeDano = false;
                MudarParaBulletHell();
            }
        }
    }

    public void MudarParaTyper()
    {
        typer = Instantiate(GameAssets.i.pfTyper);
        playerRB.velocity = Vector3.zero;
        player.position = (posicaoOriginalPlayer);
        boss.position = (posicaoOriginalBoss);
        laser.enabled = false;
        bossMov.enabled = false;
        posicaoTiros.enabled = false;
        playerMov.enabled = false;

        mododeDano = true;
        tempoRestante = TempoPorTurno;
    }

    private void MudarParaBulletHell()
    {
        Destroy(typer);
        bossMov.enabled = true;
        laser.enabled = true;
        posicaoTiros.enabled = true;
        playerMov.enabled = true;
        bossMov.posicaoAtual = 0;
        bossMov.posicaoDestino = 1;
    }

    public void MorteInimigo()
    {
        Destroy(typer);
        playerMov.enabled = true;
        mododeDano = false;
    }
}
