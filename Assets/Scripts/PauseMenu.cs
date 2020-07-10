using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private float samSpeed;

    #region singleton
    public static PauseMenu instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("more than 1 instance of PauseMenu");
            return;

        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion


    public static bool Paused = false;

    public GameObject PauseMenuUI;
    void Update()
    {

        if (Input.GetButtonDown("Close") && !InventoryUI.isInventoryActive && !CameraManager.map && !ChestInventoryUI.isChestInventoryActive && !openCraftStation.isCraftInterfaceOpen)
        {
            if(Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SamController.instance.canMove = true;
        Paused = false;

    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        SamController.instance.canMove = false;
        Paused = true;

    }

    public void LoadSettings()
    {
        Debug.Log("Menu paramètres");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
}
