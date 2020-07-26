using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Equiptment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public EquipmentSlot equipSlot;

    public int armourMod;
    public int damageMod;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
