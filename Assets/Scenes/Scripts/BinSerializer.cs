using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinSerializer : MonoBehaviour
{
    public static void Serialize(string path, object data) // Сохранение
    {
        using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate)) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }

    public static T Deserialize<T>(string path) // Загрузка
    {
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            T data = (T) formatter.Deserialize(stream);
            return data;
        }
    }
}

