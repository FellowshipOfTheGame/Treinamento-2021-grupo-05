using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject[] aviso;
    [SerializeField] private GameObject[] raio;

    private Inimigo iScript;
    private Posicao_Tiros ptScript;

    private int ataque;
    private int contadorAtaque = 0;
    //private float tempoAtaque = 0f;
    private bool fimAtaque = false;

    [SerializeField] private float tempoPiscada;
    private float bancoPiscada;

    private bool fimPiscada = false;
    private int contadorPiscada = 0;

    public bool fimSequencia = true;

    private void Awake()
    {
        iScript = GetComponent<Inimigo>();
        ptScript = GetComponent<Posicao_Tiros>();
        bancoPiscada = tempoPiscada;
    }


    void Update()
    {
        if(!fimSequencia)
        {
            switch (ataque)
            {
                case 0:
                    DentroParaFora();
                    break;
                case 1:
                    ForaParaDentro();
                    break;
                case 2:
                    Alternado();
                    break;
                default:
                    break;
            }
        }
    }

    public void Rand()
    {
        if (fimSequencia)
        {
            ataque = Random.Range(0, 3);
            fimSequencia = false;
        }
    }

    private void Alternado()
    {
        switch (contadorAtaque)
        {
            case 0:
                Ataque(1, 3);
                break;
            case 1:
                Ataque(2, -1);
                break;
            case 2:
                Ataque(1, 3);
                break;
            case 3:
                Ataque(0, 4);
                break;
            default:
                contadorAtaque = 0;
                fimSequencia = true;
                tempoPiscada = bancoPiscada;
                ptScript.numAtaques++;
                ptScript.fimAtaque = true;
                break;
        }
    }

    private void ForaParaDentro()
    {
        switch (contadorAtaque)
        {
            case 0:
                Ataque(0, 4);
                break;
            case 1:
                Ataque(1, 3);
                break;
            case 2:
                Ataque(2, -1);
                break;
            default:
                contadorAtaque = 0;
                fimSequencia = true;
                tempoPiscada = bancoPiscada;
                ptScript.numAtaques++;
                ptScript.fimAtaque = true;
                break;
        }
    }

    private void DentroParaFora()
    {
        switch(contadorAtaque)
        {
            case 0:
                Ataque(2, -1);
                break;
            case 1:
                Ataque(1, 3);
                break;
            case 2:
                Ataque(0, 4);
                break;
            default:
                contadorAtaque = 0;
                fimSequencia = true;
                tempoPiscada = bancoPiscada;
                ptScript.numAtaques++;
                ptScript.fimAtaque = true;
                break;
        }
    }

    private void Ataque(int posAviso, int posAviso2)
    {
        if (!fimPiscada && contadorPiscada == 0)
        {
            StartCoroutine (Piscar(posAviso));

            if(posAviso2 != -1)
            {
                StartCoroutine(Piscar(posAviso2));
            }

            contadorPiscada = 1;
        }
        else if(fimPiscada && contadorPiscada == 1)
        {
            StartCoroutine(Ataque(posAviso));

            if (posAviso2 != -1)
            {
                StartCoroutine(Ataque(posAviso2));
            }

            contadorPiscada = 2;

        }
        else if (fimAtaque)
        {
            contadorPiscada = 0;
            contadorAtaque++;
            fimPiscada = false;
            fimAtaque = false;
        }
    }

    private IEnumerator Piscar(int posAviso)
    {

        for (int i = 0; i < 3; i++)
        {
            aviso[posAviso].SetActive(true);

            yield return new WaitForSeconds(tempoPiscada);
            aviso[posAviso].SetActive(false);

            yield return new WaitForSeconds(tempoPiscada);
        }
        fimPiscada = true;
    }

    private IEnumerator Ataque(int posAviso)
    {
        raio[posAviso].SetActive(true);

        yield return new WaitForSeconds(1f);

        raio[posAviso].SetActive(false);
        fimAtaque = true;
    }
}
