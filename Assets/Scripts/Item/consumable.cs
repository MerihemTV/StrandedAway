using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New consumable", menuName = "Inventory/item/consumable")]
public class consumable : Item
{
    public int healValue;

    public override void use()
    {
        SamController sam = SamController.instance;
        //mettre la fonctionnalité ici
        base.use();
        sam.hp = Mathf.Clamp(sam.hp + healValue,0,100);
        Inventory.instance.removeItem(itemName);
    }
}
