using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piedestal : Interactable
{
    public Sprite piedestalEmpty;
    private static bool empty = false;
    public GameObject bloqueCombat;

    new private void Start()
    {
        base.Start();
        if (empty)
        {
            GetComponent<SpriteRenderer>().sprite = piedestalEmpty;
        }
    }

    public override void interact()
    {
        SamController.instance.canMove = false;
        GetComponent<SpriteRenderer>().sprite = piedestalEmpty;
        empty = true;
        GameObject.Find("Chef_du_village_peacefull").GetComponent<DialogueChefDuVillage>().JewelStole();
        GameObject.Find("GuardLine").SetActive(false);
        bloqueCombat.SetActive(true);
    }
}

