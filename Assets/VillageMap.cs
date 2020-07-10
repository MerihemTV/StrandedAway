using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageMap : Interactable
{
    public GameObject dialogueCanvas;

    public override void interact()
    {
        dialogueCanvas.SetActive(true);
    }
}
