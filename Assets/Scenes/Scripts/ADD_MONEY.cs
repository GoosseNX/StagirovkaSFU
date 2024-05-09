using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ADD_MONEY : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void Start()
    {
        GameDataHolder.MoneyChanged += OnMoneyChanged;
    }
    public void OnMoneyChanged(int money)
    {
        _text.text = $"—чет : {money}";
        Debug.Log("Hi");


    }
    public void OnDestroy()
    {
        GameDataHolder.MoneyChanged -= OnMoneyChanged;
    }
}
