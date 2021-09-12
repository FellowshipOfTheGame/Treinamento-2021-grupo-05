using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    private float largura, inicialPos;
    [SerializeField] private float velocidade;
    private float inicialPosVal;
    void Start()
    {
        inicialPos = transform.position.x;
        largura = GetComponent<SpriteRenderer>().bounds.size.x;
        inicialPosVal = inicialPos;
    }

    void Update()
    {
        float modificador = inicialPosVal - (velocidade * Time.deltaTime);
        inicialPosVal = modificador;
        transform.position = new Vector3(modificador, transform.position.y, transform.position.y);

        if(inicialPosVal < -largura)
        {
            inicialPosVal = largura + 1f;
        }
    }
}
