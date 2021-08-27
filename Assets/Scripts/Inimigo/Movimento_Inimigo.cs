using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_Inimigo : MonoBehaviour
{
    public float velocidadeMovimento;
    [SerializeField] private Transform[] ponto;

    private int posicaoAtual;
    private int posicaoDestino;

    [SerializeField] private float dano;
    private Transform destino;
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

        if (Vector2.Distance(transform.position, ponto[posicaoAtual].position) == 0 && !parar)
        {
            destino = ponto[posicaoDestino];
            tempoEspera = 1f;
            parar = true;

            if (posicaoAtual == ponto.Length - 1)
                posicaoAtual = 0;
            else
                posicaoAtual++;

            if (posicaoDestino == ponto.Length - 1)
                posicaoDestino = 0;
            else
                posicaoDestino++;
        }

        if (!parar)
        {
            transform.position = Vector2.MoveTowards(transform.position, destino.position, velocidadeMovimento);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            collision.GetComponent<Vida>().Dano(dano);
    }
}
