using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField] private GameObject telaMorte;

    [SerializeField] private Image atual;
    [SerializeField] private float vidaTotal;
    [SerializeField] private Text highScore;
    [SerializeField] private Text atualScore;
    [SerializeField] private Animator anim;
    private GerenciadorSom gerenciadorSom;
    private float vidaAtual;

    [SerializeField] private float iFrame;
    private float invencibilidade;

    private bool morto;

    private void Awake()
    {
        gerenciadorSom = GerenciadorSom.instancia;
        anim = GetComponent<Animator>();
        atual.fillAmount = 1;
        vidaAtual = vidaTotal;
    }

    // Update is called once per frame
    void Update()
    {
        atual.fillAmount = vidaAtual / vidaTotal;

        invencibilidade += Time.deltaTime;
    }

    public void Dano(float _dano)
    {
        if(invencibilidade>iFrame)
        {
            StartCoroutine(AnimacaoDano(_dano));
        }

        if(vidaAtual <= 0 && !morto)
        {
            gerenciadorSom.Stop();
            gerenciadorSom.TocarEfeito("lose");
            telaMorte.SetActive(true);
            highScore.text = Score.highScore.ToString();
            atualScore.text = Score.atualScore.ToString();
            Time.timeScale = 0;
            morto = true;
        }
    }

    private IEnumerator AnimacaoDano(float _dano)
    {
        anim.Play("dano");
        vidaAtual = Mathf.Clamp(vidaAtual - _dano, 0, vidaTotal);
        invencibilidade = 0f;
        yield return new WaitForSeconds(1f);
        anim.Play("idle");
    }
}
