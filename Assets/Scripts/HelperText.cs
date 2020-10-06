using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelperText : MonoBehaviour
{
    public StringVariable Text;

    public GameObject Panel;
    public TextMeshProUGUI DisplayText;

    private void Update()
    {
        if(string.IsNullOrEmpty(Text.Value))
        {
            Panel.SetActive(false);
            DisplayText.gameObject.SetActive(false);
        } else
        {
            Panel.SetActive(true);
            DisplayText.gameObject.SetActive(true);
            DisplayText.text = Text.Value;
        }
    }
}
