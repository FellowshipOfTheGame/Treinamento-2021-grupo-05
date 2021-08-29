using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupDano : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disapperTimer;
    private Color textColor;
    [SerializeField] private Transform danoPopup;
    public PopupDano Criar(Vector3 position, int damagemAmount)
    {
        position = PosicaoAleatoria(position);
        Transform popupDanoTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);

        PopupDano PopupDano = popupDanoTransform.GetComponent<PopupDano>();
        PopupDano.Setup(damagemAmount);

        return PopupDano;
    }

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    private Vector3 PosicaoAleatoria(Vector3 posicao)
    {
        Vector3 posicaoAleatoria;
        posicaoAleatoria.x = Random.Range(posicao.x - 1, posicao.x + 1);
        posicaoAleatoria.y = Random.Range(posicao.y, posicao.y + 1);
        posicaoAleatoria.z = posicao.z;

        return posicaoAleatoria;
    }

    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
        textColor = textMesh.color;
        disapperTimer = 1f;
    }

    private void Update()
    {
        float moveYSpeed = .20f;
        transform.position += new Vector3(0, moveYSpeed * Time.deltaTime);

        disapperTimer -= Time.deltaTime;

        if (disapperTimer < 0)
        {
            float disapperSpeed = 3f;
            textColor.a -= disapperSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
