using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPath : Interactable
{
    public GameObject destination = null;
    private GameObject transition_screen = null;

    public override void interact()
    {
        StartCoroutine(interactWithTransition());
    }

    public IEnumerator interactWithTransition()
    {
        if (transition_screen == null)
        {
            transition_screen = GameObject.Find("TransitionScreen");
        }

        transition_screen.GetComponent<Animator>().Play("Transition_white_to_black");
        yield return new WaitForSecondsRealtime(1f);
        SamController.instance.transform.position = destination.transform.position;
        transition_screen.GetComponent<Animator>().Play("Transition_black_to_white");

    }
}
