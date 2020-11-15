using UnityEngine;
using System.Collections;

public class PlayerStats : CharacterStats
{
    EquipmentManager equipmentManager;
    PlayerManager playerManager;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        equipmentManager = EquipmentManager.instance;
        equipmentManager.onEquipmentChangedCallback += OnEquipmentChanged;

        playerManager = PlayerManager.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Die()
    {
        base.Die();

        playerManager.isDead = true;

        Debug.Log(playerManager.isDead);
    }
}
