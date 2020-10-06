using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private ObjectPool _parent;

    public void SetParentPool(ObjectPool parent)
    {
        _parent = parent;
    }

    public void Release()
    {
        if(_parent == null)
        {
            Debug.LogWarning("Trying to release PoolObject without ObjectPool... Destroying instead");
            Destroy(gameObject);
        }
        _parent?.Release(gameObject);
    }

}
