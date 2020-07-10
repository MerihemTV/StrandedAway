using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItem : MonoBehaviour
{
    public List<Item> NeededItems;
    public List<int> numberOfItemNeeded;

    public Dialogue iaCraftedDialogue = null;

    private void Awake()
    {
        openCraftStation.updateUIDelegate += updateUI;
    }

    public Item craftedItem;

    public void craftItem()
    {
        if (isCraftable())
        {
            for (int i = 0; i < NeededItems.Count; i++)
            {
                for (int j = 0; j < numberOfItemNeeded[i]; j++)
                {
                    if (Inventory.instance.items.Contains(NeededItems[i]))
                    {
                        Inventory.instance.removeItem(NeededItems[i]);
                    }
                    else if (ChestInventory.instance.items.Contains(NeededItems[i]))
                    {
                        ChestInventory.instance.removeItem(NeededItems[i]);
                    }
                    else
                    {
                        Debug.Log("il y a un problème dans la verification du nombre d'item");
                        return;
                    }
                }
            }
            Inventory.instance.addItem(craftedItem);
            if (craftedItem.itemName == "ia")
            {
                FindObjectOfType<DialogueManager>().StartDialogue(iaCraftedDialogue);
            }
        }
        else
            Debug.Log("you cannot craft this item");
        openCraftStation.updateUIDelegate();
    }

    public bool isCraftable()
    {
        bool isCraftable = true;
        List<Item> chestAndInventory = new List<Item>();
        if (Inventory.instance.items.Count!=0)
            chestAndInventory.AddRange(Inventory.instance.items);
        if (ChestInventory.instance.items.Count != 0)
            chestAndInventory.AddRange(ChestInventory.instance.items);
        for (int i = 0; i < NeededItems.Count; i++)
        {
            isCraftable = isCraftable && HasInChestAndInventory(chestAndInventory, NeededItems[i], numberOfItemNeeded[i]);
        }
        return isCraftable;
    }

    public void updateUI()
    {
        if (isCraftable())
        {
            GetComponentInChildren<Button>().interactable = true;
            GetComponentsInChildren<Image>()[1].color = Color.white;
        }
        else
        {
            GetComponentInChildren<Button>().interactable = false;
            GetComponentsInChildren<Image>()[1].color = Color.grey;
        }
    }

    bool HasInChestAndInventory(List<Item> items, Item item, int number)
    {
        int count = 0;
        foreach (Item it in items)
        {
            if (it == item)
                count++;
        }
        return count >= number;
    }
}
