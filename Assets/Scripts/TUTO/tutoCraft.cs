using System.Collections;
using UnityEngine;

public class tutoCraft : MonoBehaviour
{
    public Dialogue dialoguePreBurger;
    public Dialogue dialoguePostBurger;

    private bool HasEatBurger = false;

    private DialogueManager Dm;
    [HideInInspector]
    public bool burgerAte = false;

    private void Start()
    {
        Dm = FindObjectOfType<DialogueManager>();
        StartCoroutine(startDialogue());
        SamController.instance.hp = 2;
    }

    private void Update()
    {
        if (SamController.instance.hp == SamController.instance.maxhp && !burgerAte)
        {
            HasEatBurger = true;
            burgerAte = true;
        }
        if (HasEatBurger)
        {
            Dm.StartDialogue(dialoguePostBurger);
            HasEatBurger = false;
        }
    }

    IEnumerator startDialogue()
    {
        yield return new WaitForSeconds(1);
        Dm.StartDialogue(dialoguePreBurger);
    }
}
