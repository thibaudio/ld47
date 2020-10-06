using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float Speed;

    public IntVariable OrbitSpeed;

    public float CurrentOrbitSpeed;
    public float CurrentSpeed;


    private void OnEnable()
    {
        if (OrbitSpeed != null) CurrentOrbitSpeed = OrbitSpeed.Value;
        else CurrentOrbitSpeed = 0f;

        CurrentSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * CurrentSpeed * Time.deltaTime, Space.Self);
        if(CurrentOrbitSpeed != 0) transform.Translate(Vector3.right * -1f * CurrentOrbitSpeed * Time.deltaTime, Space.Self);
    }

    private void OnDisable()
    {
        GetComponentInChildren<TrailRenderer>()?.Clear();
    }

    public void Slow(float slowingPower)
    {
        if (CurrentSpeed > 0)
        {
            CurrentSpeed -= slowingPower;
            if (CurrentSpeed < 0) CurrentSpeed = 0;
        }
        if (CurrentOrbitSpeed > 0)
        {
            CurrentOrbitSpeed -= slowingPower;
            if (CurrentOrbitSpeed < 0) CurrentOrbitSpeed = 0;
        }
    }
}
