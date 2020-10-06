using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public float ForwardSpeed;
    public float BackSpeed;
    public float MouseRotSpeed;

    public Transform Head;
    public Transform Body;

    public float PitchMin;
    public float PitchMax;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        if (ForwardSpeed == 0 && BackSpeed == 0) return;
        Vector3 translation = Vector3.zero;
        float forward = Input.GetAxisRaw("Vertical");
        if (forward != 0)
        {
            translation += forward * Vector3.forward;
        }

        float strafe = Input.GetAxisRaw("Horizontal");
        if (strafe != 0)
        {
            translation += strafe * Vector3.right;
        }

        translation.Normalize();

        if (translation.z > 0) translation *= ForwardSpeed;
        else translation *= BackSpeed;

        translation *= Time.deltaTime;

        transform.Translate(translation, Space.Self);
    }

    private void Rotate()
    {
        if (MouseRotSpeed == 0) return;

        Vector3 bodyRotation = new Vector3(0, Input.GetAxisRaw("Mouse X"), 0) * MouseRotSpeed * Time.deltaTime;

        Body.transform.Rotate(bodyRotation, Space.Self);

        Vector3 headRot = new Vector3(-Input.GetAxisRaw("Mouse Y"), 0, 0) * MouseRotSpeed * Time.deltaTime;

        Head.transform.Rotate(headRot, Space.Self);

    }
}
