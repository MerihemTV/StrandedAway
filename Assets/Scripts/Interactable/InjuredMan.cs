using UnityEngine.SceneManagement;
using UnityEngine;

public class InjuredMan : Interactable
{
    public Dialogue dialogueEntree;
    public Dialogue dialogueVillage;
    public Dialogue dialogueSave;
    public Dialogue dialogueKill;

    private DialogueManager Dm;

    public GameObject dialogueCanvas;
    public int gainKarma;
    public int baisseKarma;
    public Item LeKarmaPOurLesNuls;
    public static bool hasBeenSaved = false;
    public static bool isDead = false;
    private int nbDialogue = 0;


    private void Awake()
    {
        Dm = FindObjectOfType<DialogueManager>();
        if (((hasBeenSaved || isDead) && SceneManager.GetActiveScene().name == "Mountain")
              || (!hasBeenSaved && SceneManager.GetActiveScene().name == "Village"))
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Dm.DialogueEnded && nbDialogue == 0 && !hasBeenSaved)
        {
            nbDialogue++;
            dialogueCanvas.SetActive(true);
            Dm.DialogueEnded = false;
        }
        else if (Dm.DialogueEnded && nbDialogue == 1 )
        {
            nbDialogue++;
            gameObject.SetActive(false);
        }
    }

    public override void interact()
    {
        if (!hasBeenSaved)
        {
            instanciatedSprite.SetActive(false);
            Dm.StartDialogue(dialogueEntree);
        }
        else
            Dm.StartDialogue(dialogueVillage);
    }


    public void helpInjuredMan()
    {
        Dm.StartDialogue(dialogueSave);
        SamController.instance.karma += gainKarma;
        dialogueCanvas.SetActive(false);
        hasBeenSaved = true;
    }

    public void KillInjuredMan()
    {
        Dm.StartDialogue(dialogueKill);
        SamController.instance.karma -= baisseKarma;
        dialogueCanvas.SetActive(false);
        Inventory.instance.addItem(LeKarmaPOurLesNuls);
        isDead = true;
    }
}
