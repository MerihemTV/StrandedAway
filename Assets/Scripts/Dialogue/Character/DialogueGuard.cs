using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGuard : Interactable
{
    public Dialogue dialogueFlashLight;
    public Dialogue dialoguePassage;
    private DialogueManager Dm;

    new private void Start()
    {
        base.Start();
        Dm = FindObjectOfType<DialogueManager>();
    }

    public override void interact()
    {
        if (!Inventory.instance.hasInInventory("FlashLight", 1))
        {
            Dm.StartDialogue(dialogueFlashLight);
        }
        else
        {
            Dm.StartDialogue(dialoguePassage);
        }
    }
}
