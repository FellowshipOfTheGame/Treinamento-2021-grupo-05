using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float TempoPorTurno = 2f;
    [SerializeField] private Movimento_Inimigo bossMov;
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

    private void Start()
    {
        posicaoOriginalBoss = boss.position;
        
        posicaoOriginalPlayer = player.position;
        tempoRestante = TempoPorTurno;
        
    }
    void Update()
    {
        if (tempoRestante > 0)
        {
            tempoRestante -= Time.deltaTime;
        }
        if (tempoRestante <= 0)
        {
            tempoRestante = TempoPorTurno;
            if (!mododeDano)
            {
                mododeDano = true;
                MudarParaTyper();
            }
            else
            {
                mododeDano = false;
                MudarParaBulletHell();
            }
        }
    }

    private void MudarParaTyper()
    {
        typer = Instantiate(GameAssets.i.pfTyper);
        playerRB.velocity = Vector3.zero;
        player.position = (posicaoOriginalPlayer);
        boss.position = (posicaoOriginalBoss);
        laser.enabled = false;
        bossMov.enabled = false;
        posicaoTiros.enabled = false;
        playerMov.enabled = false;
    }

    private void MudarParaBulletHell()
    {
        Destroy(typer);
        bossMov.enabled = true;
        laser.enabled = true;
        posicaoTiros.enabled = true;
        playerMov.enabled = true;
    }
}
