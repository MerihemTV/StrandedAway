using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnLaunch : MonoBehaviour
{
    // Start is called before the first frame update
    public static int launching;
    public SamController controller;
    void Start()
    {
        LaunchFirst();
        SceneManager.sceneLoaded += Launch;

    }

    void LaunchFirst()
    {
        if (launching == 1)
        {
            controller.LoadPlayer();
            launching = 2;
        }

        if (launching == 0)
        {
            //RESET LE JEU
            launching = 2;
        }
    }
    void Launch(Scene scene, LoadSceneMode mode)
    {
        if (launching == 1)
        {
            controller.LoadPlayer();
            launching = 2;
        }

        if (launching == 0)
        {
            //RESET LE JEU
            launching = 2;
        }
    }
}
