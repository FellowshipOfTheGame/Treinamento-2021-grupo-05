using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoPalavras : MonoBehaviour
{
    private List<string> listaPalavras = new List<string>()
    {
        "sidewalk", "defend", "three", "protect", "firewall",
         "database", "antivirus", "software", "test", "hardware", "science",
         "computer", "theory", "data", "dangerous", "complex", "system", "learn",
         "process", "artificial", "parallel", "information", "theory", "network",
         "ip", "port", "wifi", "graphics", "signal", "modern", "digital",
         "calculator", "cards", "laboratory", "field", "logic", "circuit",
         "model", "language", "stop", "play"
    };

    public string PalavraAleatoria()
    {

        int numeroAleatorio = Random.Range(0, listaPalavras.Count);
        return listaPalavras[numeroAleatorio];
    }
}
