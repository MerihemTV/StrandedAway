using UnityEngine;

public class ChestInventoryUI : MonoBehaviour
{
    ChestInventory Chestinventory;
    public Transform itemsParent;
    InventorySlot[] slots;
    public GameObject ChestinventoryUI;
    public static bool isChestInventoryActive = false;

    public enum QuickInvSlot { up, down, left, right, none };

    #region singleton
    public static ChestInventoryUI instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("more than 1 instance of inventoryUI");
            return;

        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
        Chestinventory = ChestInventory.instance;
        Chestinventory.onItemChangedCallBackChest += updateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetButtonDown("Close") || Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("left") || Input.GetKeyDown("right")) 
            && isChestInventoryActive)
        {
            closeChest();
        }
    }


    void updateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < ChestInventory.instance.items.Count)
            {
                slots[i].addItem(ChestInventory.instance.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }

     public void openChest()
    {
        ChestinventoryUI.SetActive(!ChestinventoryUI.activeSelf);
        isChestInventoryActive = !isChestInventoryActive;
        InventoryUI.instance.inventoryUI.SetActive(true);
    }

    public void closeChest()
    {
        ChestinventoryUI.SetActive(!ChestinventoryUI.activeSelf);
        isChestInventoryActive = !isChestInventoryActive;
        InventoryUI.instance.inventoryUI.SetActive(false);
    }
}
