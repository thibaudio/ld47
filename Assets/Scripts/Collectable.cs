using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class Collectable : MonoBehaviour
{
    public GameEvent Collected;

    private PoolObject _po;
    private MovingObject _mo;

    public LayerMask CollectedBy;
    public LayerMask DestroyedBy;

    private void Awake()
    {
        _po = GetComponent<PoolObject>();
        _mo = GetComponent<MovingObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((( 1 << other.gameObject.layer) & CollectedBy) != 0)
        {
            Collected.Raise();
            _po.Release();
            return;
        }

        if (((1 << other.gameObject.layer) & DestroyedBy) != 0)
        {
            _po.Release();
        }
    }
}
