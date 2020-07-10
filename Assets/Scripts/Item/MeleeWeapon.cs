using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MeleeWeapon", menuName = "Inventory/item/MeleeWeapon")]
public class MeleeWeapon : Item
{
    public float DamageOnHit;

    public override void use()
    {
        base.use();
        SamController.instance.EquipMeleeWeapon(this);
    }
}
