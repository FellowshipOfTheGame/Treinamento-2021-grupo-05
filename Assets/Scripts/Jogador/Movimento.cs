using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    [SerializeField] private float velocidade;

    public Rigidbody2D body;

    private float inputHorizontal;
    private float inputVertical;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        body.velocity = new Vector2(inputHorizontal * velocidade, inputVertical * velocidade);
    }
}
