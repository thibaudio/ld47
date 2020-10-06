using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryTargtSpawner : MonoBehaviour
{
    public GameEvent TargetSpawn;
    public float WarningTime;

    public GameObject TargetPrefab;
    public Transform OrbitTarget;
    

    public float DelayMin;
    public float DelayMax;

    public float MinY;
    public float MaxY;

    private float _cd = 0;
    private bool _warned = false;
    private int _targetToSpawn = 0;
    private ObjectPool _pool;

    private void Awake()
    {
        _pool = new ObjectPool(transform, TargetPrefab, 5);
    }

    public void OnPackageCollected()
    {
        _targetToSpawn++;
    }

    private void Update()
    {
        if(_cd <= 0)
        {
            if (_targetToSpawn > 0)
            {
                _cd = Random.Range(DelayMin, DelayMax);
                _warned = false;
            } else return;
        }

        _cd -= Time.deltaTime;

        if (_cd <= WarningTime && !_warned)
        {
            TargetSpawn.Raise();
            _warned = true;
        }

        if (_cd <= 0)
        {
            GameObject go = _pool.Get();

            Vector3 position = transform.position;
            position.y += Random.Range(MinY, MaxY);

            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            go.GetComponent<Orbit>().Target = OrbitTarget;
            _targetToSpawn--;
        }
    }
}
