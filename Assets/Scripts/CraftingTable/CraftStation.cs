using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftStation : Interactable
{
    public Canvas craftCanva;
    public override void interact()
    {
        craftCanva.GetComponent<openCraftStation>().openInterface();
    }
}
