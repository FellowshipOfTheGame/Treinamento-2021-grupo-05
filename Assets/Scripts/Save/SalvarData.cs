using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public static class SalvarData
{
   
    public static void SaveScore(Score informacoes)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/Score.sav", FileMode.Create);

        ScoreData data = new ScoreData(informacoes);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static int[] LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/Score.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/Score.sav", FileMode.Open);

            ScoreData data = bf.Deserialize(stream) as ScoreData;

            stream.Close();

            return data.scoreLista;
        }
        else
        {
            Debug.Log("save não existe");
            return new int[2];
        }

        
    }

    [Serializable]
    public class ScoreData
    {
        public int[] scoreLista;

        public ScoreData(Score salvar)
        {
            scoreLista = new int[2];
            scoreLista[0] = Score.highScore;
            scoreLista[1] = Score.atualScore;
        }
    }
}