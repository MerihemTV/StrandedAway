using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    #region singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("plus d'une instance d'inventaire trouvé");
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    #endregion

    public int maxNbOfItems = 20;
    private int actualNbOfItems;

    public List<Item> items = new List<Item>(); 
    public bool addItem(Item item)
    {
        if (items.Count == maxNbOfItems)
        {
            Debug.Log("too much items in inventory");
            return false;
        }
        items.Add(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void removeItem(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }

    public void removeItem(string name)
    {
        for (int i = 0; i<items.Count; i++)
        {
            if (items[i].itemName == name)
            {
                removeItem(items[i]);
            }
        }
    }

    //check if there is enough of a signle ressource in the inventory with a given name and umber
    public bool hasInInventory(string name, int number)
    {
        int count = 0;
        foreach(Item item in items)
        {
            if (item.itemName == name)
                count++;
        }
        return count >= number;
    }

    public int howManyItemOf(Item item)
    {
        int count = 0;
        foreach (Item it in items)
        {
            if (it == item)
                count++;
        }
        return count;
    }
}
