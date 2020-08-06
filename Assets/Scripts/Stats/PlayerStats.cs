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
}
