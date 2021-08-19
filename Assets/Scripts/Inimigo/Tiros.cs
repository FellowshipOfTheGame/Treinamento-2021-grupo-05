using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tiros : MonoBehaviour
{
    [SerializeField] private float velocidadeTiro;
    [SerializeField] private float dano;
    private float vX;
    private float vY;

    private CircleCollider2D colisao;

    private void Awake()
    {
        colisao = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        float velocidadeX = velocidadeTiro * Time.deltaTime * vX;
        float velocidadeY = velocidadeTiro * Time.deltaTime * vY;
        transform.Translate(velocidadeX, velocidadeY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Parede")
        {
            colisao.enabled = false;
            gameObject.SetActive(false);
        }
        // dano
        if (collision.tag == "Player")
        {
            collision.GetComponent<Vida>().Dano(dano);
            colisao.enabled = false;
            gameObject.SetActive(false);
        }
    }

    public void Ativar(int num)
    {
        gameObject.SetActive(true);
        colisao.enabled = true;
        vEixo(num);
    }

    private void vEixo(int posicao)
    {
        switch (posicao)
        {
            case 0:
                vX = 0.3f;
                vY = 0.519615f;
                break;
            case 1:
                vX = 0.519615f;
                vY = 0.3f;
                break;
            case 2:
                vX = 0.6f;
                vY = 0f;
                break;
            case 3:
                vX = 0.519615f;
                vY = -0.3f;
                break;
            case 4:
                vX = 0.3f;
                vY = -0.519615f;
                break;
            case 5:
                vX = 0f;
                vY = -0.6f;
                break;
            case 6:
                vX = -0.3f;
                vY = -0.519615f;
                break;
            case 7:
                vX = -0.519615f;
                vY = -0.3f;
                break;
            case 8:
                vX = -0.6f;
                vY = 0f;
                break;
            case 9:
                vX = -0.519615f;
                vY = 0.3f;
                break;
            case 10:
                vX = -0.3f;
                vY = 0.519615f;
                break;
            case 11:
                vX = 0f;
                vY = 0.6f;
                break;
            default: 
                break;
        }
    }
}