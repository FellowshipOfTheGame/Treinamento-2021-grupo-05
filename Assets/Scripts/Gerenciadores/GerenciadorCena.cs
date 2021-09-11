using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GerenciadorCena : MonoBehaviour
{
    public static GerenciadorCena instancia;
    private GerenciadorSom gerenciadorSom;
    [SerializeField] private GameObject abertura;
    [SerializeField] private GameObject imagemTrocaCena;

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

    public void IniciarGameScene()
    {
        gerenciadorSom.TocarEfeito("botao");
        abertura.SetActive(true);

        StartCoroutine(Esperar());
    }

    private IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1f);

        imagemTrocaCena.SetActive(true);
        SceneManager.LoadScene("Rodrigo");
    }
}
