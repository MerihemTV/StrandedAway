using UnityEngine;


[CreateAssetMenu(fileName ="New RangeWeapon",menuName ="Inventory/item/rangeWeapon")]
public class RangeWeapon : Item
{
    public GameObject projectile;
    public float TimeBetweenShots;

    public override void use()
    {
        base.use();
        SamController.instance.EquipRangeWeapon(this);
    }

}
