using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaMorte : MonoBehaviour
{
    [SerializeField] private GameObject telaMorteUI;
    public void Ligar()
    {
        telaMorteUI.SetActive(true);
    }
}
