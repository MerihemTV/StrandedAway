using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Button removeButton;
    public Image icon;

    public void addItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        removeButton.image.enabled = true;
    }

    public void clearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        removeButton.image.enabled = false;
    }

    public void OnRemoveButton()
    {
        if (CompareTag("InventoryTag"))
            Inventory.instance.removeItem(item);
        if (CompareTag("ChestTag"))
            ChestInventory.instance.removeItem(item);
    }

    public void useItem()
    {
        if (item != null)
        {
            
            if (!(GameObject.Find("Chest")) || (GameObject.Find("Chest") && !ChestInventoryUI.isChestInventoryActive))
            {
                item.use();
            }
            else if (CompareTag("ChestTag"))
            {
                if (Inventory.instance.items.Count < Inventory.instance.maxNbOfItems)
                {
                    Inventory.instance.addItem(item);
                    ChestInventory.instance.removeItem(item);
                }
                else
                    Debug.Log("plus de place dans l'inventaire");
            }
            
            else if (CompareTag("InventoryTag"))
            {
                if (ChestInventory.instance.items.Count < ChestInventory.instance.maxNbOfItems)
                {
                    ChestInventory.instance.addItem(item);
                    Inventory.instance.removeItem(item);
                }
                else
                    Debug.Log("plus de place dans le coffre");
            }
        }
    }
}
