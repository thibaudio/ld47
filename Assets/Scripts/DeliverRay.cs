using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverRay : MonoBehaviour
{
    public GameObject PackagePrefab;

    private ObjectPool _pool;

    public Transform RayPoint;
    public Transform PackageParent;

    public float Cooldown;

    private float _cd;

    private void Awake()
    {
        _pool = new ObjectPool(PackageParent, PackagePrefab, 5);
        _cd = 0;
    }

    private void Update()
    {
        _cd -= Time.deltaTime;
        if (Input.GetAxisRaw("Tract") > 0 && _cd <= 0)
        {
            GameObject go = _pool.Get();
            go.transform.position = RayPoint.position;
            go.transform.rotation = RayPoint.rotation;
            _cd = Cooldown;
        }
    }
}
