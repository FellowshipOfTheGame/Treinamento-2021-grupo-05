using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_Inimigo : MonoBehaviour
{
    public float velocidadeMovimento;
    [SerializeField] public Transform[] ponto;

    public int posicaoAtual;
    public int posicaoDestino;

    [SerializeField] private float dano;
    public Transform destino;
    private bool parar;
    public float tempoEspera;

    void Awake()
    {
        destino = ponto[1];
        posicaoAtual = 1;
        posicaoDestino = 2;
    }

    void Update()
    {
        Mover();
    }

    private void Mover()
    {
        if (parar)
            tempoEspera -= Time.deltaTime;

        if (tempoEspera <= 0)
            parar = false;

        if (!parar)
        {
            transform.position = Vector2.MoveTowards(transform.position, destino.position, velocidadeMovimento);
        }

        if (Vector2.Distance(transform.position, ponto[posicaoAtual % ponto.Length].position) <= float.Epsilon && !parar)
        {
            destino = ponto[posicaoDestino % ponto.Length];
            tempoEspera = 1f;
            
            if(tempoEspera - 1 <= float.Epsilon)
                parar = true;

            posicaoAtual++;
            posicaoDestino++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            collision.GetComponent<Vida>().Dano(dano);
    }

    public void Fase2()
    {
        tempoEspera *= 0.8f;
        velocidadeMovimento *= 1.2f;
    }

    public void Fase3()
    {
        tempoEspera *= 0.7f;
        velocidadeMovimento *= 1.3f;
    }
}
