using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;

    public bool DialogueEnded = false;
    public Text nameText;
    public Text dialogueText;
    public Image portrait;

    private bool dialogueOn = false;
    
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if((Input.GetButtonDown("Interact") || Input.GetMouseButtonDown(0)) && dialogueOn)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        DialogueEnded = false;
        SamController.instance.canMove = false;
        animator.SetBool("isOpened", true);

        nameText.text = dialogue.name;
        portrait.sprite = dialogue.portrait;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        StartCoroutine(LockInteractionTouch());
        //dialogueOn = true;
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpened", false);
        SamController.instance.canMove = true;
        dialogueOn = false;
        DialogueEnded = true;
    }

    IEnumerator LockInteractionTouch()
    {
        yield return new WaitForEndOfFrame();
        dialogueOn = true;
    }
}
