using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCollMethod : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    public GameData gameData;

    public void SetMoney() 
    {
        Debug.Log("Hi");
        gameData.Money = gameData.Money + 1;
    }
}
