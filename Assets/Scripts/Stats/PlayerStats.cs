using UnityEngine;
using System.Collections;

public class PlayerStats : CharacterStats
{
    EquipmentManager equipmentManager;
    // Use this for initialization
    void Start()
    {
        equipmentManager = EquipmentManager.instance;
        equipmentManager.onEquipmentChangedCallback += OnEquipmentChanged;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEquipmentChanged(Equipment newItem, Equipment oldItem, GameObject instItem)
    {
        if(newItem != null)
        {
            armour.AddModifier(newItem.armourMod);
            damage.AddModifier(newItem.damageMod);
        }

        if (oldItem != null)
        {
            armour.RemoveModifier(oldItem.armourMod);
            damage.RemoveModifier(oldItem.damageMod);
        }

    }
}
