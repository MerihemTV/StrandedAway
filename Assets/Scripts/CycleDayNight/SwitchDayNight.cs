using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class SwitchDayNight : MonoBehaviour
{

    private GameObject transition_screen;
    private GameObject[] allObjects;

    private bool isDay = true;


    void Start()
    {
        transition_screen = GameObject.Find("TransitionScreen");
        allObjects = FindObjectsOfType<GameObject>();
        changeColorOnLoad();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Spaceship")
            changeColor();
    }

    public void changeColorOnLoad()
    {
        float hour = HeureController.houres_dec * 10 + HeureController.houres_unit;
        if (!isDay && hour >= 8 && hour < 20)
        {
            isDay = true;
            allObjects = FindObjectsOfType<GameObject>();
            SwitchNightToDay();
        }
        else if (isDay && (hour >= 20 || hour < 8))
        {
            isDay = false;
            allObjects = FindObjectsOfType<GameObject>();
            SwitchDayToNight();
        }
    }

    private void changeColor()
    {
        float hour = HeureController.houres_dec * 10 + HeureController.houres_unit;
        if (!isDay && hour >= 8 && hour < 20)
        {
            isDay = true;
            StartCoroutine(SwitchNightToDayCouroutine());
        }
        else if (isDay && (hour >= 20 || hour < 8))
        {
            isDay = false;
            StartCoroutine(SwitchDayToNightCouroutine());
        }
    }

    public void SwitchDayToNight()
    {
        foreach (GameObject go in allObjects)
        {
            if (go != null)
            {
                if (go.GetComponent<SpriteRenderer>() != null)
                {
                    go.GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.white, Color.blue, 0.5f);
                }
                if (go.GetComponent<Tilemap>() != null)
                {
                    go.GetComponent<Tilemap>().color = Color.Lerp(Color.white, Color.blue, 0.5f);
                }
            }
        }
    }

    public void SwitchNightToDay()
    {
        foreach (GameObject go in allObjects)
        {
            if (go != null)
            {
                if (go.GetComponent<SpriteRenderer>() != null)
                {
                    go.GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.blue, Color.white, 1f);
                }
                if (go.GetComponent<Tilemap>() != null)
                {
                    go.GetComponent<Tilemap>().color = Color.Lerp(Color.blue, Color.white, 1f);
                }
            }
        }
    }


    public IEnumerator SwitchDayToNightCouroutine()
    {
        transition_screen.GetComponent<Animator>().Play("Transition_white_to_black");
        yield return new WaitForSecondsRealtime(1f);
        allObjects = FindObjectsOfType<GameObject>();
        SwitchDayToNight();
        transition_screen.GetComponent<Animator>().Play("Transition_black_to_white");
    }

    public IEnumerator SwitchNightToDayCouroutine()
    {
        transition_screen.GetComponent<Animator>().Play("Transition_white_to_black");
        yield return new WaitForSecondsRealtime(1f);
        allObjects = FindObjectsOfType<GameObject>();
        SwitchNightToDay();
        transition_screen.GetComponent<Animator>().Play("Transition_black_to_white");
    }
}
