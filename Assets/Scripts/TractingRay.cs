using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetSystem))]
public class TractingRay : MonoBehaviour
{

    public float TractSpeed;
    public float SlowingPower;

    private TargetSystem _targetSystem;

    public LineRenderer RayEffect;

    private void Awake()
    {
        _targetSystem = GetComponent<TargetSystem>();
    }

    void Update()
    {

        if (Input.GetAxisRaw("Tract") > 0) {
            RayEffect.gameObject.SetActive(true);
            //RayEffect.SetPosition(1, _targetSystem.CurrentTarget.transform.position);

        } else
        {
            RayEffect.gameObject.SetActive(false);
        }

        if (Input.GetAxisRaw("Tract") > 0 && _targetSystem.CurrentTarget != null)
        {
            Vector3 tractDir = transform.position - _targetSystem.CurrentTarget.transform.position;

            _targetSystem.CurrentTarget.transform.Translate(tractDir * TractSpeed * Time.deltaTime, Space.World);

            MovingObject mo = _targetSystem.CurrentTarget.GetComponent<MovingObject>();
            mo?.Slow(SlowingPower);
        }
    }
}
