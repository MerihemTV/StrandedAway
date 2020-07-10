using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public Transform itemsParent;
    InventorySlot[] slots;
    public GameObject inventoryUI;
    public static bool isInventoryActive = false;

    public enum QuickInvSlot {up,down,left,right,none};

    #region singleton
    public static InventoryUI instance;
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
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += updateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            isInventoryActive = !isInventoryActive;
        }

        if(Input.GetButtonDown("Close") && isInventoryActive)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            isInventoryActive = !isInventoryActive;
        }

        if (isInventoryActive)
            if (!(GameObject.Find("Chest")) || (GameObject.Find("Chest") && !ChestInventoryUI.isChestInventoryActive))
            {
                SetToQuickInventory();
            }


    }
    
    void updateUI()
    {
        for (int i=0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].addItem(inventory.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }

    void SetToQuickInventory()
    {
        // création d'un raycast graphique pour detecter l'UI
        GraphicRaycaster gr = GetComponent<GraphicRaycaster>();
        PointerEventData ped = new PointerEventData(null);
        ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(ped, results);  //results contient les collisions du raycast

        //on créer un expression reguliaire pour connaitre l'item a mettre dans l'inventaire rapide
        Regex regex = new Regex("(ItemSlot)(.(.|$))");

        //si "touche 1" appuyé alors assigné l'item correspondant au pointeur de la souris dans le slot 1 de l'inventaire rapide
        if (results != null && results.Count != 0)
        {
            MatchCollection matches = regex.Matches(results[0].gameObject.transform.parent.parent.name);
            if (matches.Count > 0)
            {
                int index = int.Parse(matches[0].Groups[2].ToString());
                if (Input.GetButtonDown("Inv1"))
                {
                    setItemToQuickInv(QuickInvSlot.up,Inventory.instance.items[index]);
                }
                if (Input.GetButtonDown("Inv2"))
                {
                    setItemToQuickInv(QuickInvSlot.left, Inventory.instance.items[index]);
                }
                if (Input.GetButtonDown("Inv3"))
                {
                    setItemToQuickInv(QuickInvSlot.right, Inventory.instance.items[index]);
                }
                if (Input.GetButtonDown("Inv4"))
                {
                    setItemToQuickInv(QuickInvSlot.down, Inventory.instance.items[index]);
                }

            }
        }
        
    }

    private void setItemToQuickInv(QuickInvSlot slot, Item item)
    {

        QuickInvSlot QuickSlot = QuickInvManager.instance.isItemAlreadyIn(item);

        Debug.Log("slot  : " + QuickSlot);
        switch (QuickSlot)
        {
            case QuickInvSlot.up:
                QuickInvManager.instance.setItemHaut(null);
                break;
            case QuickInvSlot.left:
                QuickInvManager.instance.setItemGauche(null);
                break;
            case QuickInvSlot.right:
                QuickInvManager.instance.setItemDroit(null);
                break;
            case QuickInvSlot.down:
                QuickInvManager.instance.setItemBas(null);
                break;
            default:
                break;
        }
        switch (slot)
        {
            case QuickInvSlot.up:
                QuickInvManager.instance.setItemHaut(item);
                break;
            case QuickInvSlot.left:
                QuickInvManager.instance.setItemGauche(item);
                break;
            case QuickInvSlot.right:
                QuickInvManager.instance.setItemDroit(item);
                break;
            case QuickInvSlot.down:
                QuickInvManager.instance.setItemBas(item);
                break;
            default:
                break;
        }
    }
}


