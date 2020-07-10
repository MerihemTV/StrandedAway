using System.Collections;
using UnityEngine;

public class PickUpInteractable : Interactable
{
    public Item item ;
    public const float timer = 100;
    public Item NeededItem = null;

    float currCountdownValue;

    public override void interact()
    {
        if (NeededItem == null || Inventory.instance.hasInInventory(NeededItem.itemName, 1))
        {
            if (item != null)
            {
                if (!Inventory.instance.addItem(item))
                {
                    Debug.Log("I cannot pickup more items my inventory is full");
                    return;
                }
            }
            StartCoroutine(StartCountdown());
        }
        else
        {
            Debug.Log("you need " + NeededItem.itemName + " to collect this ressource");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && currCountdownValue <= 0.5f)
            instanciatedSprite.SetActive(true);
    }

    public IEnumerator StartCountdown(float countdownValue = timer)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponents<BoxCollider2D>()[0].enabled = false;
        GetComponents<BoxCollider2D>()[1].enabled = false;
        instanciatedSprite.SetActive(false);
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponents<BoxCollider2D>()[0].enabled = true;
        GetComponents<BoxCollider2D>()[1].enabled = true;
    }
}
