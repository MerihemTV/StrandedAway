using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPlanet : Interactable
{
    public Dialogue notYetDialogue;
    public string scene;
    private GameObject transition_screen = null;
    private GameObject tuto;
    private DialogueManager Dm;

    new private void Start()
    {
        base.Start();
        tuto = GameObject.Find("TutoCraft");
        Dm = FindObjectOfType<DialogueManager>();
    }

    public override void interact()
    {
        if (tuto.GetComponent<tutoCraft>().burgerAte)
        {
            StartCoroutine(interactWithTransition());
        }
        else
        {
            Dm.StartDialogue(notYetDialogue);
        }
    }

    public IEnumerator interactWithTransition()
    {
        if (transition_screen == null)
        {
            transition_screen = GameObject.Find("TransitionScreen");
        }
        transition_screen.GetComponent<Animator>().Play("Transition_white_to_black");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(scene);
        SamController.instance.transform.position = new Vector3(10, -3, 0);
        ZoneName.zone = "Vaisseau";
        transition_screen.GetComponent<Animator>().Play("Transition_black_to_white");
    }
}
