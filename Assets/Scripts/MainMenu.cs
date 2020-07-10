using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void NewGame()
    {
        LoadOnLaunch.launching = 0;
        SceneManager.LoadScene("Camp");
    }

    public void LoadGame()
    {
        LoadOnLaunch.launching = 1;
        SceneManager.LoadScene("Camp");

    }

    public void Settings()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
