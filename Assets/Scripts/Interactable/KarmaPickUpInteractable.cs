using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarmaPickUpInteractable : PickUpInteractable
{
    public int baisseKarma;
    private static bool firstOnePicked = true;

    public override void interact()
    {
        base.interact();
        SamController.instance.karma -= baisseKarma;
        Debug.Log("karma : " + SamController.instance.karma);
        if (firstOnePicked)
        {
            Debug.Log("you shouldn't steal other's people food");
            firstOnePicked = false;
        }
    }
}
    
