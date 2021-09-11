using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tiros : MonoBehaviour
{
    [SerializeField] private float velocidadeTiro;

    private float bancoVelocidade;

    [SerializeField] private float dano;
    private GameObject inimigo;
    private GameObject temporizador;
    [SerializeField] private Respawn rScript;
    public bool respawn = false;
    private Timer tScript;
    private Inimigo iScript;

    private float vX;
    private float vY;

    private BoxCollider2D colisao;

    private void Awake()
    {
        colisao = GetComponent<BoxCollider2D>();
        inimigo = GameObject.Find("Inimigo");
        temporizador = GameObject.Find("Timer");
        tScript = temporizador.GetComponent<Timer>();
        iScript = inimigo.GetComponent<Inimigo>();

        rScript.bancoVelocidadeTiros = velocidadeTiro;
        iScript.ataqueOriginal = velocidadeTiro;
    }

    void Update()
    {
        if(tScript.mododeDano)
        {
            //velocidadeTiro = bancoVelocidade;
            gameObject.SetActive(false);
        }

        float velocidadeX = velocidadeTiro * Time.deltaTime * vX;
        float velocidadeY = velocidadeTiro * Time.deltaTime * vY;
        transform.Translate(velocidadeX, velocidadeY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Parede")
        {
            velocidadeTiro = rScript.bancoVelocidadeTiros;
            colisao.enabled = false;
            gameObject.SetActive(false);
        }
        // dano
        if (collision.tag == "Player")
        {
            velocidadeTiro = rScript.bancoVelocidadeTiros;
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

    public void Explodir(int num)
    {
        gameObject.SetActive(true);
        colisao.enabled = true;
        Cabum(num);
    }

    private void vEixo(int posicao)
    {
        velocidadeTiro = rScript.bancoVelocidadeTiros;

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

        // velocidade errada pacas
        //Vector2 posicaoRelativa = inimigo.transform.InverseTransformPoint(pScript.bala[posicao].transform.position);

        /*Vector2 distancia = pScript.bala[posicao].transform.position - inimigo.transform.position;

        vX = Vector3.Dot(distancia, inimigo.transform.right.normalized);
        vY = Vector3.Dot(distancia, inimigo.transform.up.normalized);*/
    }

    private void Cabum(int posicao)
    {
        velocidadeTiro = rScript.bancoVelocidadeTiros;

        switch (posicao)
        {
            case 0:
                vX = 0.6f;
                vY = 0f;
                break;
            case 1:
                vX = 0.3f;
                vY = 0.519615f;
                break;
            case 2:
                vX = -0.3f;
                vY = 0.519615f;
                break;
            case 3:
                vX = -0.6f;
                vY = 0f;
                break;
            case 4:
                vX = 0.3f;
                vY = -0.519615f;
                break;
            case 5:
                vX = -0.3f;
                vY = -0.519615f;
                break;
            default:
                break;
        }
    }
}
