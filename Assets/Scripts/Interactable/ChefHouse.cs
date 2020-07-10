using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefHouse : Interactable
{
    public GameObject lich;
    public static ChefHouse instance;
    #region singleton


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("plus d'une instance de maison du chef" +
                " trouvé");
            return;
        }
        instance = this;
    }

    #endregion

    public bool isDay = true;

    public bool HaveSeenLich = false;

    public override void interact()
    {
        if (HaveSeenLich && !isDay)
        {
            Debug.Log("you introduce in the house to pee everywhere");
            HaveSeenLich = false;
            lich.SetActive(false);
        }
        else if (HaveSeenLich && isDay)
        {
            Debug.Log("I should wait until the night falls to go in");
        }
        else
        {
            Debug.Log("This house seems to belong to the chief");
        }
    }
}
