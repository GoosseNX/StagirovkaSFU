using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinEvent : MonoBehaviour
{
    public UnityEvent _CoinCollectt;

    public void CoinColl()
    {
        _CoinCollectt.Invoke();
    }

}
