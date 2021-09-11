using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject menuPausa;
    [SerializeField] private GerenciadorSom gerenciadorScript;
    private bool pausado = false;

    private void Awake()
    {
        gerenciadorScript = FindObjectOfType<GerenciadorSom>();
    }
    private void Start()
    {
        menuPausa.SetActive(false);
    }

    private void Update()
    {
        // pausa e despausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausado = !pausado;
            gerenciadorScript.TocarEfeito("botao");

           

        }
        if (pausado)
        {

            menuPausa.SetActive(true);
            // para o tempo
            Time.timeScale = 0f;
        }
        else
        {

            menuPausa.SetActive(false);
            Time.timeScale = 1f;
        }



    }

    public void Voltar()
    {
        gerenciadorScript.TocarEfeito("botao");
        pausado = false;
    }

    public void Reiniciar()
    {
        gerenciadorScript.TocarEfeito("botao");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuPrincipal()
    {
        
        gerenciadorScript.TocarEfeito("botao");
        SceneManager.LoadScene("MenuScene");
    }

    public void Sair()
    {
        gerenciadorScript.TocarEfeito("botao");
        Application.Quit();
    }
}
