using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChefDuVillage : Interactable
{
    private DialogueManager Dm;
    public Dialogue dialogueStandard;
    public Dialogue dialoguePremierZoneJoyaux;
    public Dialogue dialogueTeteLezard;
    public Dialogue dialogueVoleJoyaux;

    public GameObject EnergieJewel;

    private bool giveJewel = false;
    private float speed = 7f;
    private GameObject sam;
    private bool mustMove1 = false;
    private bool mustMove2 = false;
    private bool leave = false;
    private bool fight = false;
    private Vector3 prev_pos;

    new void Start()
    {
        base.Start();
        Dm = FindObjectOfType<DialogueManager>();
        sam = GameObject.Find("Sam");
    }

    public override void interact()
    {
        if (!Inventory.instance.hasInInventory("LezardHead", 1))
        {
            Dm.StartDialogue(dialogueStandard);
        }
        else
        {
            Dm.StartDialogue(dialogueTeteLezard);
            giveJewel = true;
        }
    }

    private void Update()
    {
        if (leave && Dm.DialogueEnded)
        {
            Vector3 target_pos = new Vector3(-18.56f, -51.85f, 0) - transform.position;
            GetComponent<Rigidbody2D>().MovePosition(transform.position + (target_pos.normalized) * Time.deltaTime * speed);
            if (target_pos.magnitude < 0.1)
            {
                leave = false;
                transform.position = prev_pos;
            }
        }

        if (Dm.DialogueEnded && giveJewel)
        {
            Instantiate(EnergieJewel, transform.position + new Vector3(0, -3, 0), transform.rotation);
            giveJewel = false;
        }
        if (Dm.DialogueEnded && fight)
        {
            GameObject AngryChef = GameObject.Find("Chef_du_village");
            fight = false;
            AngryChef.GetComponent<Chef_du_villageController>().enableMove();
            AngryChef.GetComponent<Chef_du_villageController>().tp_to_fight();
            StartCoroutine(destroyChef());
        }
    }

    private void FixedUpdate()
    {
        if (mustMove1)
        {
            Vector3 target_pos = (sam.transform.position + new Vector3(-2, 0, 0)) - transform.position;
            GetComponent<Rigidbody2D>().MovePosition(transform.position + (target_pos.normalized) * Time.deltaTime * speed);
            if (target_pos.magnitude < 0.1)
            {
                mustMove1 = false;
                leave = true;
                Dm.StartDialogue(dialoguePremierZoneJoyaux);
            }
               
        }
        if (mustMove2)
        {
            Vector3 target_pos = (sam.transform.position + new Vector3(0, -4, 0)) - transform.position;
            GetComponent<Rigidbody2D>().MovePosition(transform.position + (target_pos.normalized) * Time.deltaTime * speed);
            if (target_pos.magnitude < 0.1)
            {
                mustMove2 = false;
                fight = true;
                Dm.StartDialogue(dialogueVoleJoyaux);
            }

        }

    }

    public void EntreeZoneJoyaux()
    {
        SamController.instance.canMove = false;
        prev_pos = transform.position;
        transform.position = new Vector3(-18.56f, -51.85f, 0);
        mustMove1 = true;
    }

    public void JewelStole()
    {
        transform.position = new Vector3(-9.44f, -99.42f, 0);
        mustMove2 = true;
    }

    IEnumerator destroyChef()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }

}
