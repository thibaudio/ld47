using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float MinCooldown;
    public float MaxCooldown;
    public float WarnBefore;

    private float _currentCooldown;
    private ObjectPool _objectPool;

    public GameObject Prefab;

    public GameEvent NewPackage;

    private bool _raised = false;

    private void Start()
    {
        _currentCooldown = 15;

        _objectPool = new ObjectPool(transform, Prefab, 5);
    }

    void Update()
    {
        _currentCooldown -= Time.deltaTime;
        if(_currentCooldown <= WarnBefore && !_raised)
        {
            NewPackage.Raise();
            _raised = true;
        }
        if(_currentCooldown <= 0)
        {
            GameObject go = _objectPool.Get();
            go.transform.localPosition = Vector3.zero;
            go.transform.rotation = transform.rotation;
            _currentCooldown = Random.Range(MinCooldown, MaxCooldown);
            _raised = false;
        }
        
    }
}
