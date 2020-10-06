using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverRay2 : MonoBehaviour
{
    public GameObject PackagePrefab;

    private ObjectPool _pool;

    public Transform RayPoint;
    public Transform PackageParent;

    private TargetSystem _targetSystem;

    public LineRenderer OKRayEffect;
    public LineRenderer NOKRayEffect;

    public float Cooldown;
    public float Threshold;

    public IntVariable DeliverySuccesses;
    public IntVariable DeliveryFailures;
    public IntVariable Stock;
    public IntVariable Money;

    private float _cd;

    private int _okCount;
    private int _nokCount;

    private bool _activeLast;
    private bool _locked;

    private GameObject _lastTarget;

    private void Awake()
    {
        _targetSystem = GetComponent<TargetSystem>();

        _pool = new ObjectPool(PackageParent, PackagePrefab, 5);

        Reset();
    }

    private void Update()
    {
        if (_locked && Input.GetAxisRaw("Tract") > 0) return;
        if (Input.GetAxisRaw("Tract") == 0)
        {
            Reset();
            _locked = false;
            return;
        }

        if(_activeLast)
        {
            _cd += Time.deltaTime;
        } else
        {
            _activeLast = true;
            _cd = 0;
        }

        if (_lastTarget == null && _targetSystem.CurrentTarget != null) _lastTarget = _targetSystem.CurrentTarget;

        if (_targetSystem.CurrentTarget == _lastTarget && _targetSystem.CurrentTarget != null)
        {
            OKRayEffect.gameObject.SetActive(true);
            NOKRayEffect.gameObject.SetActive(false);

            _okCount++;
        } else
        {
            OKRayEffect.gameObject.SetActive(false);
            NOKRayEffect.gameObject.SetActive(true);
            _nokCount++;
        }

        if (_cd >= Cooldown)
        {
            if ((float)_okCount / ((float)_okCount + (float)_nokCount) >= Threshold && Stock.Value > 0)
            {
                DeliverySuccesses.Value++;
                Stock.Value--;
                Money.Value++;
                GameObject go = _pool.Get();
                go.transform.position = RayPoint.position;
                go.transform.rotation = RayPoint.rotation;
            }
            _locked = true;
            Reset();
        }
    }

    private void Reset()
    {
        OKRayEffect.gameObject.SetActive(false);
        NOKRayEffect.gameObject.SetActive(false);
        _okCount = 0;
        _nokCount = 0;
        _activeLast = false;
        _cd = 0;
        _lastTarget = null;
    }
}
