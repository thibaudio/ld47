using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float Speed;
    public Transform Target;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Target.position, Target.up, Time.deltaTime * Speed);
    }
}
