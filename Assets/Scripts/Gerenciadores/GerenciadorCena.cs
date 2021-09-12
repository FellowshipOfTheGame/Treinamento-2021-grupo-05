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

    public void IniciarGameScene()
    {
        SceneManager.LoadScene("Rodrigo");
    }

    
}
