using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public struct GameData
{
    public int Money;

}
public static class GameDataHolder
{
    private static int money;

    public static int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            MoneyChanged?.Invoke(money);
        }

    }
    public static Action<int> MoneyChanged;
}
