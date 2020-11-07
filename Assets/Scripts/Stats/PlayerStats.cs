using UnityEngine;
using System.Collections;

public class PlayerStats : CharacterStats
{
    EquipmentManager equipmentManager;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        equipmentManager = EquipmentManager.instance;
        equipmentManager.onEquipmentChangedCallback += OnEquipmentChanged;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
