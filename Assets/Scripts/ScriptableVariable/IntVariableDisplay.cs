using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntVariableDisplay : MonoBehaviour
{
    public IntVariable IntVariable;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = IntVariable.Value.ToString();
    }
}
