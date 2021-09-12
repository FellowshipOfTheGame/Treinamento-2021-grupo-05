using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarTimer : MonoBehaviour
{
    [SerializeField] private Text contadorTexto;
    [SerializeField] private Movimento_Inimigo bossMov;
    [SerializeField] private Posicao_Tiros posicaoTiros;
    [SerializeField] private Laser laser;
    [SerializeField] private Movimento playerMov;
    [SerializeField] private GameObject telaTutorial;

    public bool mododeDano = false;
    private int contador = 3;

    private void Awake()
    {
        
        StartCoroutine(Contador());
    }
    void Start()
    {
        Time.timeScale = 0f;
    }

   private IEnumerator Contador()
    {
        while(contador > 0)
        {
            contadorTexto.text = contador.ToString();

            yield return new WaitForSeconds(1f);

            contador--;
        }

        contadorTexto.text = "GO!";
        bossMov.enabled = true;
        laser.enabled = true;
        posicaoTiros.enabled = true;
        playerMov.enabled = true;

        yield return new WaitForSeconds(1f);


        contadorTexto.gameObject.SetActive(false);

    }

    public void FecharTutorial()
    {
        Time.timeScale = 1f;
        telaTutorial.SetActive(false);
    }
}
