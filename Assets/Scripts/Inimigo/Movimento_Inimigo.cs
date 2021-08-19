using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_Inimigo : MonoBehaviour
{
    public float velocidadeMovimento;
    [SerializeField] private Transform pontoA;
    [SerializeField] private Transform pontoB;
    [SerializeField] private float dano;
    private Transform destino;
    private bool parar;
    private float tempoEspera;

    void Awake()
    {
        destino = pontoB;
    }

    void Update()
    {
        //v += velocidadeMovimento * Time.deltaTime;
        if (parar)
            tempoEspera -= Time.deltaTime;

        if (Vector2.Distance(transform.position, pontoB.position) == 0 && !parar)
        {
            destino = pontoA;
            parar = true;
        }

        if (Vector2.Distance(transform.position, pontoA.position) == 0 && !parar)
        {
            destino = pontoB;
            parar = true;
        }

        if(parar && tempoEspera<=0f)
        {
            parar = false;
            tempoEspera = 1f;
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
