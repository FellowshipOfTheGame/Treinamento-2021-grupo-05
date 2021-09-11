using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public int numInimigosMortos;
    public bool isMorto = false;
    [SerializeField] private GameObject inimigo;
    [SerializeField] private Transform pontoRespawn;
    [SerializeField] private Transform destino;
    private Posicao_Tiros posicaoScript;
    private Movimento_Inimigo movimentoScript;
    private Laser laserScript;
    public float bancoVelocidadeTiros;
    public int bancoTirosMax;
    private Inimigo inimigoScript;
    private bool isParado = true;

    void Start()
    {
        posicaoScript = inimigo.GetComponent<Posicao_Tiros>();
        movimentoScript = inimigo.GetComponent<Movimento_Inimigo>();
        inimigoScript = inimigo.GetComponent<Inimigo>();
        laserScript = inimigo.GetComponent<Laser>();
    }

    void Update()
    {
        if (isMorto)
            StartCoroutine(Spawn());
        if (!isParado)
            Mover();
    }

    private void Mover()
    {
        inimigo.transform.position = Vector2.MoveTowards(inimigo.transform.position, destino.position, 0.004f);
        if (inimigo.transform.position == destino.position)
            isParado = true;
    }

    private IEnumerator Spawn()
    {
        isMorto = false;
        inimigo.SetActive(true);
        posicaoScript.enabled = false;
        movimentoScript.enabled = false;
        laserScript.enabled = false;
        
        inimigo.transform.position = pontoRespawn.position;

        isParado = false;

        yield return new WaitForSeconds(5f);

        inimigoScript.vidaTotal += 20;
        inimigoScript.vida = inimigoScript.vidaTotal;

        yield return new WaitForSeconds(2f);

        posicaoScript.enabled = true;
        movimentoScript.enabled = true;
        laserScript.enabled = true;

        // so funciona a movimentacao no ponto A e no ponto C

        movimentoScript.posicaoAtual = 0;
        movimentoScript.posicaoDestino = 1;
        movimentoScript.destino = movimentoScript.ponto[0];
    }
}
