using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{

    public GameObject PlayerGO;

    private float _cd;

    private void OnEnable()
    {
        _cd = 2;
    }

    private void Update()
    {
        if (_cd > 0) 
        {
            _cd -= Time.deltaTime;
            return;
        }
        if(Input.GetAxisRaw("Use") > 0)
        {
            PlayerGO.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
