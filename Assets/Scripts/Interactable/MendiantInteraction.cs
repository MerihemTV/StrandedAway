using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//il ne reste plus qu'a implémenter le fait qu'on peut lui donner des pommes qu'une seul fois par jour
public class MendiantInteraction : Interactable
{
    public int numberOfApple;
    public int gainKarma;
    private bool alreadyDoneToday = false;

    public override void interact()
    {
        if (alreadyDoneToday)
        {
            Debug.Log("you can't give him more apple today");
        }
        else
        {
            if (Inventory.instance.hasInInventory("apple", numberOfApple))
            {
                SamController.instance.karma += gainKarma;
                Debug.Log("sam's karma : " + SamController.instance.karma);
                for (int i = 0; i < 10; i++)
                {
                    Inventory.instance.removeItem("apple");
                }
                alreadyDoneToday = true;
            }
            else
                Debug.Log("you don't have enough apple");
        }
    }
}
