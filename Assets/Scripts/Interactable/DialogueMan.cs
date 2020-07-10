using UnityEngine;

public class DialogueMan : Interactable
{
    public Dialogue dialogue;

    public override void interact()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
