using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using System.IO;


public class SaveLoadMethod : MonoBehaviour
{
    [SerializeField] private string _FileName;
    [SerializeField] private GameData _GameData;
    public int Money;

    public void Save() 
    {
        string _PathToSaveFile = Path.Combine(Application.streamingAssetsPath, _FileName);
        BinSerializer.Serialize(_PathToSaveFile, _GameData);
        
        Debug.Log("Save");
    }
    public void Load()
    {
        string _PathToSaveFile = Path.Combine(Application.streamingAssetsPath, _FileName);

        if (File.Exists(_PathToSaveFile)) 
        {
            _GameData = BinSerializer.Deserialize<GameData>(_PathToSaveFile);
            GameDataHolder.Money = _GameData.Money;
        }
        Debug.Log("Load");
    }
}
