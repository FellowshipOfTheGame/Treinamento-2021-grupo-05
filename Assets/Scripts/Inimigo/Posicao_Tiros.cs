using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicao_Tiros : MonoBehaviour
{
    public Transform[] posicao;

    public GameObject[] bala;

    public float coolDown;
    private int contador = 0;


    void Start()
    {
        
    }

    void Update()
    {
        PrimeiraFase();
    }

    private void PrimeiraFase()
    {
        if (coolDown <= 0f)
        {
            if (contador == 0)
            {
                inicioTiro(posicao[2], 2);
                inicioTiro(posicao[5], 5);
                inicioTiro(posicao[8], 8);
                inicioTiro(posicao[11], 11);
                contador = 1;
            }
            else if(contador == 1)
            {
                inicioTiro(posicao[1], 1);
                inicioTiro(posicao[4], 4);
                inicioTiro(posicao[7], 7);
                inicioTiro(posicao[10], 10);
                contador = 2;
            }
            else if(contador == 2)
            {
                inicioTiro(posicao[0], 0);
                inicioTiro(posicao[3], 3);
                inicioTiro(posicao[6], 6);
                inicioTiro(posicao[9], 9);
                contador = 0;
            }
            coolDown = 0.7f;
        }

        coolDown -= Time.deltaTime;
    }

    private void inicioTiro(Transform posicao, int num)
    {
        bala[PoolTiros()].transform.position = posicao.position;
        bala[PoolTiros()].GetComponent<Tiros>().Ativar(num);
    }

    public float dadosTiro(/*Transform posicao*/char eixo)
    {
        float v = 0;

        if (eixo == 'x')
            v = posicao[3].position.x;
        else if (eixo == 'y')
            v = posicao[3].position.y;

        return v;
    }

    private int PoolTiros()
    {
        for (int i = 0; i < bala.Length; i++)
        {
            if (!bala[i].activeInHierarchy)
                return i;
        }

        return 0;
    }
}
