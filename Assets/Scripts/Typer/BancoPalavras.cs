using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoPalavras : MonoBehaviour
{
    private List<string> listaPalavras = new List<string>()
    {
        "sidewalk", "robin", "three", "protect", "periodic",
         "somber", "majestic", "jump", "pretty", "wound", "jazzy",
         "mug", "hot", "tart", "dangerous", "mother", "rustic", "economic",
         "weird", "cut", "parallel", "wood", "encouraging", "interrupt",
         "guide", "long", "chief", "mom", "signal", "rely", "abortive",
         "hair", "representative", "earth", "grate", "proud", "feel",
         "hilarious", "addition", "silent", "play", "floor", "numerous",
         "friend", "pizzas", "building", "organic", "past", "mute", "unusual",
         "mellow", "analyse", "crate", "homely", "protest", "painstaking",
         "society", "head", "female", "eager", "heap", "dramatic", "present",
         "sin", "box", "pies", "awesome", "root", "available", "sleet", "wax",
         "boring", "smash", "anger", "tasty", "spare", "tray", "daffy", "scarce",
         "account", "spot", "thought", "distinct", "nimble", "practise", "cream",
         "ablaze", "thoughtless", "love", "verdict", "giant"
    };

    public string PalavraAleatoria()
    {

        int numeroAleatorio = Random.Range(0, listaPalavras.Count);
        return listaPalavras[numeroAleatorio];
    }
}
