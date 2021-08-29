using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{

    [SerializeField] private Text textTyper;
    [SerializeField] private BancoPalavras banco;
    private GameObject boss;
    private Inimigo bossScript;
    public int danoPalavra = 10;
    private string palavraAtual = string.Empty;
    private string palavraRestante = string.Empty;

    private void Awake()
    {
        boss = GameObject.FindGameObjectWithTag("Inimigo");
        bossScript = boss.GetComponent<Inimigo>();
    }
    private void Start()
    {
        AgregarPalavraAtual();
    }

    private void AgregarPalavraAtual()
    {
        palavraAtual = banco.PalavraAleatoria();
        AgregarPalavraRestante(palavraAtual);
    }

    private void Update()
    {
        foreach (char letra in Input.inputString)
        {
            letraDigitada(letra);
        }
    }

    private void AgregarPalavraRestante(string palavra)
    {
        palavraRestante = palavra;
        textTyper.text = palavraRestante;
    }

    private bool letraCerta(char letra)
    {
        return palavraRestante.IndexOf(letra) == 0;
    }

    private void letraDigitada(char letra)
    {
        if (letraCerta(letra))
        {
            RemoverLetra();
            if (PalavraAcabou())
            {
                bossScript.LevarDano(danoPalavra);
                AgregarPalavraAtual();
            }
        }
    }

    private bool PalavraAcabou()
    {
        return palavraRestante.Length == 0;
    }

    private void RemoverLetra()
    {
        string newString = palavraRestante.Remove(0, 1);
        AgregarPalavraRestante(newString);
    }


}
