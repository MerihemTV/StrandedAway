using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInvManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static QuickInvManager instance;

    public AssignedItem itemHaut = null;

    public AssignedItem itemBas = null;

    public AssignedItem itemGauche = null;

    public AssignedItem itemDroit = null;


    #region singleton
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("plus d'une instance d'inventaire trouvé");
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        if (!InventoryUI.isInventoryActive)
        {
            if (Input.GetButtonDown("Inv1") && itemHaut != null)
            {
                    itemHaut.UseItem();
                    manageItem(itemHaut);
            }
            if (Input.GetButtonDown("Inv2") && itemGauche != null)
            {
                    itemGauche.UseItem();
                    manageItem(itemGauche);
            }
            if (Input.GetButtonDown("Inv3") && itemDroit != null)
            {
                    itemDroit.UseItem();
                    manageItem(itemDroit);
            }
            if (Input.GetButtonDown("Inv4") && itemBas != null)
            {
                    itemBas.UseItem();
                    manageItem(itemBas);
            }
        }
    }

    public void setItemHaut(Item newItem)
    {
        itemHaut.SetItem(newItem);
    }

    public void setItemGauche(Item newItem)
    {
        itemGauche.SetItem(newItem);
    }

    public void setItemDroit(Item newItem)
    {
        itemDroit.SetItem(newItem);
    }

    public void setItemBas(Item newItem)
    {
        itemBas.SetItem(newItem);
    }

    public void manageItem(AssignedItem Aitem)
    {
        if ( Aitem!=null && Aitem.item.GetType() == typeof(consumable) && !Inventory.instance.hasInInventory(Aitem.item.itemName,1))
        {
            Aitem.RemoveItem();
        }
    }

    public InventoryUI.QuickInvSlot isItemAlreadyIn(Item item)
    {
        
        if (itemHaut.item!=null && item.itemName == itemHaut.item.itemName)
        {
            return InventoryUI.QuickInvSlot.up;
        }
        else if (itemGauche.item != null && item.itemName == itemGauche.item.itemName)
        {
            return InventoryUI.QuickInvSlot.left;
        }
        else if (itemDroit.item != null && item.itemName == itemDroit.item.itemName)
        {
            return InventoryUI.QuickInvSlot.right;
        }
        else if (itemBas.item != null && item.itemName == itemBas.item.itemName)
        {
            return InventoryUI.QuickInvSlot.down;
        }
        return InventoryUI.QuickInvSlot.none;
    }
}
