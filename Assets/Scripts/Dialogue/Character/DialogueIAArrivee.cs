using System.Collections;
using UnityEngine;

public class DialogueIAArrivee : MonoBehaviour
{
    public Dialogue DialogueArrivee;
    private DialogueManager Dm;

    private static bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        if (first)
        {
            first = false;
            Dm = FindObjectOfType<DialogueManager>();
            StartCoroutine(startDialogue());
        }
    }


    IEnumerator startDialogue()
    {
        yield return new WaitForSeconds(1);
        Dm.StartDialogue(DialogueArrivee);
    }
}
