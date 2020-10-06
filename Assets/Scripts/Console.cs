using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour, IInteractable
{

    public GameObject PlayerGO;
    public GameObject TurretGO;

    public string HelperText;

    public string GetHelperText()
    {
        return HelperText;
    }

    public void Interact()
    {
        PlayerGO.SetActive(false);
        TurretGO.SetActive(true);
    }
}
