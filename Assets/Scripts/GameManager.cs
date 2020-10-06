using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int DrainMoneyEvery;
    public int DrainMoneyAmount;
    public int StartingMoney;

    public IntVariable Money;
    public IntVariable Stock;
    public IntVariable DeliverySuccesses;
    public IntVariable DeliveryFailures;

    private float _cd;

    public BoolVariable Menu;
    public GameObject MenuDisplay;

    private bool _pressed = false;

    void Start()
    {
        _cd = DrainMoneyEvery;
        Money.Value = StartingMoney;
        Stock.Value = 0;
        MenuDisplay.SetActive(false);
        Menu.Value = false;
    }

    void Update()
    {
        _cd -= Time.deltaTime;
        if(_cd <= 0)
        {
            Money.Value -= DrainMoneyAmount;
            _cd = DrainMoneyEvery;
        }

        if(Money.Value <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("StartScene");
        }

        if (Input.GetAxisRaw("Escape") > 0 && !_pressed)
        {
            _pressed = true;
            if (Menu.Value)
            {
                OnContinue();
            } else
            {
                MenuDisplay.SetActive(true);
                Menu.Value = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        } else if (Input.GetAxisRaw("Escape") == 0)
        {
            _pressed = false;
        }
    }

    public void OnContinue()
    {
        MenuDisplay.SetActive(false);
        Menu.Value = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;

    }

    public void OnBackToMain()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1;
    }

    public void OnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
