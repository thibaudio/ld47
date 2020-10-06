using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryTarget : MonoBehaviour
{
    public float MaxX;
    private PoolObject _po;

    private void Awake()
    {
        _po = GetComponent<PoolObject>();
    }

    void Update()
    {
        if(transform.position.x > MaxX)
        {
            _po.Release();
        }
    }
}
