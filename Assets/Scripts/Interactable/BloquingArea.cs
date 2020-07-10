using UnityEngine;

public class BloquingArea : Interactable
{
    public Item NeededItem = null;
    public static bool log = true;
    public static bool boulder = true;
    public static bool CaveBoulder = true;
    public static bool guard = true;

    private void Awake()
    {
        if (!log && gameObject.name == "blocageMontagne")
        {
            gameObject.SetActive(false);
        }
        if (!boulder && gameObject.name == "boulder")
        {
            gameObject.SetActive(false);
        }
        if (!CaveBoulder && gameObject.name == "CaveBoulder")
        {
            gameObject.SetActive(false);
        }
        if (!guard && gameObject.name == "Guard")
        {
            gameObject.SetActive(false);
        }
    }

    public override void interact()
    {
        if (NeededItem == null || Inventory.instance.hasInInventory(NeededItem.itemName, 1))
        {
            gameObject.SetActive(false);
            if (gameObject.name == "blocageMontagne")
            {
                log = !log;
            }
            if (gameObject.name == "boulder")
            {
                boulder = !boulder;
            }
            if (gameObject.name == "CaveBoulder")
            {
                CaveBoulder = !CaveBoulder;
            }
            if (gameObject.name == "Guard")
            {
                guard = !guard;
            }
        }
        else
        {
            Debug.Log("you need " + NeededItem.itemName + " to pass throught this obstacle");
        }
    }
}
