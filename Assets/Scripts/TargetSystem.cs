using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    public float Radius;
    public float Distance;

    public GameObject CurrentTarget;

    public LayerMask TargetLayerMask;

    public Camera TargetSystemCamera;

    void Update()
    {
        Vector3 lineOrigin = TargetSystemCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f)) - TargetSystemCamera.transform.forward*2;
        Debug.DrawRay(lineOrigin, TargetSystemCamera.transform.forward * Distance, Color.green);
        if (Physics.SphereCast(lineOrigin, Radius, TargetSystemCamera.transform.forward, out RaycastHit hitInfo, Distance, TargetLayerMask))
        {
            CurrentTarget = hitInfo.collider.gameObject;
        } else
        {
            CurrentTarget = null;
        }
    }
}
