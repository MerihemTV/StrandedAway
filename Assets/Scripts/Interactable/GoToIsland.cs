using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToIsland : ChangeScene
{
    public override void interact()
    {
        if (Inventory.instance.hasInInventory("engine", 1))
        {
            StartCoroutine(interactWithTransition());
        }
        else
        {
            Debug.Log("you need the engine to start the boat");
        }
    }
}
