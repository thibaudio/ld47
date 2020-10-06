using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    public IntVariable StockAmount;

    private void Awake()
    {
        StockAmount.Value = 0;
    }

    public void OnCollect()
    {
        StockAmount.Value++;
    }
}
