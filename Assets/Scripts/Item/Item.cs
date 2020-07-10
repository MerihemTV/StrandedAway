using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/item/basic" )]
public class Item : ScriptableObject
{
    public string itemName = "New item";
    public Sprite icon = null;

    public virtual void use()
    {
        Debug.Log("using: " + itemName);
    }
}
