using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScene : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void OnThibaudIO()
    {
        Application.OpenURL("https://twitter.com/thibaudio");
    }
}
