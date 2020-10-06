using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private List<GameObject> _pool;
    private int _index;
    private GameObject _prefab;
    private Transform _parentTransform;
    public ObjectPool(Transform parentTransform, GameObject prefab, int preallocSize)
    {
        _prefab = prefab;
        _parentTransform = parentTransform;
        _pool = new List<GameObject>();
        for (int i = 0; i < preallocSize; i++)
        {
            Allocate();
        }
        _index = 0;
    }

    private void Allocate()
    {
        GameObject go = GameObject.Instantiate(_prefab, _parentTransform);
        go.SetActive(false);
        go.GetComponent<PoolObject>().SetParentPool(this);
        _pool.Add(go);
    }

    public GameObject Get()
    {
        if (_index < _pool.Count)
        {
            GameObject go = _pool[_index];
            go.SetActive(true);
            _index++;
            return go;
        } else
        {
            Allocate();
            return Get();
        }
    }

    public void Release(GameObject go)
    {
        go.SetActive(false);
        _pool.Remove(go);
        _pool.Add(go);
        _index--;
    }
}
