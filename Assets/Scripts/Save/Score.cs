using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int highScore;
    public static int atualScore;

    public void Salvar()
    {
        PlayerPref.SetScore(highScore);
    }

    public void Carregar()
    {
        highScore = PlayerPref.GetScore();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}