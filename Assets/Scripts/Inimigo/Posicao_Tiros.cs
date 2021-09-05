using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicao_Tiros : MonoBehaviour
{
    public Transform[] posicao;

    public GameObject[] bala;

    public GameObject[] carregado;

    private Laser laserScript;
    [SerializeField] private Timer timerScript;

    private float coolDown;

    [SerializeField] private float maxCooldown;

    private int contadorAlternado = 0;
    private bool inicioCarregado = false;

    private int contadorBurst = 0;
    private int numTiros = 0;
    [SerializeField] private int tirosMax;
    private int numAtaques = 0;

    private bool fimAtaque = true;
    int ataque;


    void Awake()
    {
        laserScript = GetComponent<Laser>();
    }

    void Update()
    {
        coolDown -= Time.deltaTime;

        if (fimAtaque)
        {
            ataque = Random.Range(0, 3);
            fimAtaque = false;
        }

        if(!fimAtaque && numAtaques<= tirosMax-1)
        {
            switch(ataque)
            {
                case 0:
                    AtaqueAlternado();
                    break;
                case 1:
                    AtaqueBurst();
                    break;
                case 2:
                    laserScript.Rand();
                    break;
                default:
                    break;
            }
        }
        else if(!fimAtaque && numAtaques == tirosMax)
        {
            AtaqueCarregado();
            timerScript.MudarParaTyper();
        }
        //AtaqueCarregado();
    }

    private void AtaqueAlternado()
    {
        if (coolDown <= 0f)
        {
            if (contadorAlternado == 15)
            {
                contadorAlternado = 0;
                fimAtaque = true;
                numAtaques++;
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

    private void AtaqueBurst()
    {
        // falta criar o algoritmo para atirar varias balas seguidas

        if (coolDown <= 0f)
        {
            if (contadorBurst == 6)
            {
                contadorBurst = 0;
                fimAtaque = true;
                numAtaques++;
                return;
            }

            if (contadorBurst % 2 == 0)
            {
                if (numTiros < 3)
                {
                    inicioTiro(posicao[10], 10);
                    inicioTiro(posicao[11], 11);
                    inicioTiro(posicao[0], 0);

                    inicioTiro(posicao[4], 4);
                    inicioTiro(posicao[5], 5);
                    inicioTiro(posicao[6], 6);

                    numTiros++;

                    coolDown = maxCooldown / 4;
                }
                else
                {
                    coolDown = maxCooldown;
                    contadorBurst += 1;
                    numTiros = 0;
                }
            }
            else
            {

                if (numTiros < 3)
                {
                    inicioTiro(posicao[1], 1);
                    inicioTiro(posicao[2], 2);
                    inicioTiro(posicao[3], 3);

                    inicioTiro(posicao[7], 7);
                    inicioTiro(posicao[8], 8);
                    inicioTiro(posicao[9], 9);

                    numTiros++;

                    coolDown = maxCooldown / 4;
                }
                else
                {
                    contadorBurst += 1;
                    numTiros = 0;
                    coolDown = maxCooldown;
                }
            }
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
            StartCoroutine(MudancaTyper());
        }
    }

    private IEnumerator MudancaTyper()
    {
        yield return new WaitForSeconds(4f);

        numAtaques = 0;
        timerScript.MudarParaTyper();
    }

    private void inicioTiro(Transform posicao, int num)
    {
        // num representa a posicao de inicio do tiro, em que num = hora do relogio - 1

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
