using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetSystem))]
public class Interact : MonoBehaviour
{
    private TargetSystem _targetSystem;

    public StringVariable HelperText;

    private float _cd;

    public BoolVariable Menu;

    private void Awake()
    {
        _targetSystem = GetComponent<TargetSystem>();
    }

    private void OnEnable()
    {
        _cd = 2;
    }

    void Update()
    {
        if (_cd > 0)
        {
            _cd -= Time.deltaTime;
            return;
        }

        if (_targetSystem.CurrentTarget != null)
        {
            if (string.IsNullOrEmpty(HelperText.Value)) HelperText.Value = _targetSystem.CurrentTarget.GetComponent<IInteractable>().GetHelperText();
            if (Input.GetAxisRaw("Use") > 0)
            {
                _targetSystem.CurrentTarget.GetComponent<IInteractable>().Interact();
                HelperText.Value = "";
            }
        } else
        {
            HelperText.Value = "";
        }       
    }
}
