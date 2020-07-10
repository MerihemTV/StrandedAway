using UnityEngine;
using UnityEngine.UI;

public class AssignedItem : MonoBehaviour
{
    // Start is called before the first frame update

    public Item item;
    public Image icon;

    void Start()
    {
    }

    // Update is called once per frame
    public void UseItem()
    {
        if (item != null)
        {
            item.use();
        }
        
    }

    public void SetItem(Item newItem)
    {
        if (newItem == null)
        {
            item = null;
            icon.sprite = null;
            icon.enabled = false;
        }
        else
        {
            item = newItem;
            icon.sprite = newItem.icon;
            icon.enabled = true;
        }
        
    }

    public void SetItem(AssignedItem newItem)
    {
        item = newItem.item;
        icon.sprite = newItem.item.icon;
        icon.enabled = true;
    }

    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
