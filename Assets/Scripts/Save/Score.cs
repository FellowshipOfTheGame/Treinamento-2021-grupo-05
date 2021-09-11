using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int highScore;
    public static int atualScore;

    public void Salvar()
    {
        SalvarData.SaveScore(this);
    }

    public void Carregar()
    {
        int[] loadScore = SalvarData.LoadScore();

        highScore = loadScore[0];
        atualScore = loadScore[1];
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
