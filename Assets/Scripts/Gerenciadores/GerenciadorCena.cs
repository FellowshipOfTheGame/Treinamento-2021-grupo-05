using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorCena : MonoBehaviour
{
    public static GerenciadorCena instancia;
    private GerenciadorSom gerenciadorSom;
    

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        gerenciadorSom = GerenciadorSom.instancia;
    }

    public void IniciarGameScene(GameObject abertura, GameObject error)
    {
        gerenciadorSom.TocarEfeito("botao");
        abertura.SetActive(true);

        StartCoroutine(Erro(error));
        StartCoroutine(Esperar());


    }

    private IEnumerator Esperar()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Rodrigo");
    }
    private IEnumerator Erro(GameObject error)
    {
        yield return new WaitForSeconds(1f);
        gerenciadorSom.TocarEfeito("erro");


        error.SetActive(true);
    }
}
