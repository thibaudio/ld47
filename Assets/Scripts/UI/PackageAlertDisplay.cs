using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PackageAlertDisplay : MonoBehaviour
{

    public float DisplayTime;
    private float _currentDisplayTime;

    public TextMeshProUGUI Text;
    public Image Panel;

    private Color _textColor;
    private Color _panelColor;


    private void Awake()
    {
        _textColor = Text.color;
        _panelColor = Panel.color;

        SetAlpha(0);
    }

    public void OnNewPackageEvent()
    {
        _currentDisplayTime = DisplayTime;
    }


    private void Update()
    {
        _currentDisplayTime -= Time.deltaTime;
        if (_currentDisplayTime <= 0)
        {
            SetAlpha(0);
            return;
        }

        float alpha = Mathf.Cos(_currentDisplayTime * 6 * Mathf.PI / DisplayTime) / 4 + 0.75f;
        SetAlpha(alpha);

    }


    private void SetAlpha(float a)
    {
        _textColor.a = a;
        _panelColor.a = a;

        Text.color = _textColor;
        Panel.color = _panelColor;
    }
}
