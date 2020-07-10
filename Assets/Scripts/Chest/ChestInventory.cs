using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestInventory : MonoBehaviour
{
    public static ChestInventory instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBackChest;
    private bool isActive = true;
    #region singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("plus d'une instance de coffre trouvé");
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);
    }

    #endregion

    public int maxNbOfItems = 20;
    private int actualNbOfItems;

    public List<Item> items = new List<Item>();

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if ((SceneManager.GetActiveScene().name != "Spaceship") && isActive && this!=null)
        {
            isActive = false;
            gameObject.SetActive(false);

        }
        if ((SceneManager.GetActiveScene().name == "Spaceship"||
            SceneManager.GetActiveScene().name == "SpaceShipSpace") && !isActive && this != null)
        {
            gameObject.SetActive(true);
            isActive = true; ;
        }
    }

    public bool addItem(Item item)
    {
        if (items.Count == maxNbOfItems)
        {
            Debug.Log("too much items in Chest");
            return false;
        }
        items.Add(item);
        if (onItemChangedCallBackChest != null)
        {
            onItemChangedCallBackChest.Invoke();
        }
        return true;
    }

    public void removeItem(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBackChest != null)
            onItemChangedCallBackChest.Invoke();
    }

    public void removeItem(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == name)
            {
                removeItem(items[i]);
            }
        }
    }

    //check if there is enough of a single ressource in the inventory with a given name and umber
    public bool hasInChestInventory(string name, int number)
    {
        int count = 0;
        foreach (Item item in items)
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