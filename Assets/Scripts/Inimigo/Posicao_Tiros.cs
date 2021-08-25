using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicao_Tiros : MonoBehaviour
{
    public Transform[] posicao;

    public GameObject[] bala;

    public GameObject[] carregado;

    private float coolDown;

    [SerializeField] private float maxCooldown;

    private int contadorAlternado = 0;
    private bool inicioCarregado = false;


    void Start()
    {
        
    }

    void Update()
    {
        coolDown -= Time.deltaTime;
        AtaqueAlternado();
        AtaqueCarregado();
    }

    private void AtaqueAlternado()
    {
        if (coolDown <= 0f)
        {
            if (contadorAlternado == 15)
            {
                inicioCarregado = true;
                return;
            }

            if (contadorAlternado % 3 == 0)
            {
                inicioTiro(posicao[2], 2);
                inicioTiro(posicao[5], 5);
                inicioTiro(posicao[8], 8);
                inicioTiro(posicao[11], 11);
                contadorAlternado += 1;
            }
            else if(contadorAlternado % 3 == 1)
            {
                inicioTiro(posicao[1], 1);
                inicioTiro(posicao[4], 4);
                inicioTiro(posicao[7], 7);
                inicioTiro(posicao[10], 10);
                contadorAlternado += 1;
            }
            else if(contadorAlternado % 3 == 2)
            {
                inicioTiro(posicao[0], 0);
                inicioTiro(posicao[3], 3);
                inicioTiro(posicao[6], 6);
                inicioTiro(posicao[9], 9);
                contadorAlternado += 1;
            }
            coolDown = maxCooldown;
        }
    }

    private void AtaqueCarregado()
    {
        if(coolDown <= 0f && inicioCarregado)
        {
            tiroCarregado(posicao[2], 2);
            tiroCarregado(posicao[5], 5);
            tiroCarregado(posicao[8], 8);
            tiroCarregado(posicao[11], 11);
            coolDown = 7f;
            contadorAlternado = 0;
        }
    }

    private void inicioTiro(Transform posicao, int num)
    {
        bala[PoolTiros()].transform.position = posicao.position;
        bala[PoolTiros()].GetComponent<Tiros>().Ativar(num);
    }

    private void tiroCarregado(Transform posicao, int num)
    {
        carregado[PoolCarregado()].transform.position = posicao.position;
        carregado[PoolCarregado()].GetComponent<Tiro_Carregado>().Ativar(num);
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

    private int PoolCarregado()
    {
        for (int i = 0; i < carregado.Length; i++)
        {
            if (!carregado[i].activeInHierarchy)
                return i;
        }

        return 0;
    }
}
