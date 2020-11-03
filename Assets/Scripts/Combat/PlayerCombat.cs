using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerCombat : Combat
{

    EquipmentManager equipmentManager;
    PlayerMotor motor;
    PlayerManager playerManager;

    Weapon weapon;
    GameObject instWeapon;



    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        equipmentManager = EquipmentManager.instance;
        playerManager = PlayerManager.instance;
        motor = GetComponent<PlayerMotor>();
        weapon = (Weapon)equipmentManager.GetWeapon();
        instWeapon = equipmentManager.GetInstWeapon();
        equipmentManager.onEquipmentChangedCallback += UpdateWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            if(!animationLocked && weapon != null)
                Attack();
        }

        if (Input.GetButtonDown("Block"))
        {
            //check player manager to see if there's shield equipped
            //if not, block with weapon
            if (!animationLocked)
                Block();
        }

        if (Input.GetButtonUp("Block"))
        {
            StopBlocking();
            ResumeMoving();
        }
    }

    void UpdateWeapon(Equipment newWeapon, Equipment oldItem, GameObject newInstWeapon)
    {
        if(newWeapon.GetType().Equals(typeof(Weapon)))
        {
            weapon = (Weapon)newWeapon;
            instWeapon = newInstWeapon;
        }
    }

    void ResumeMoving()
    {
        motor.EnableMoving();
    }

    public override void Attack()
    {
        motor.DisableMoving();
        motor.FaceMouse();

        StartCoroutine(PlayAttackAnimation(weapon, instWeapon, ResumeMoving));
    }

    public override void Block()
    {
        motor.DisableMoving();
        motor.FaceMouse();

        IBlocker blockingEquipment = equipmentManager.GetBlockingEquipment();

        StartCoroutine(PlayDefendAnimation(blockingEquipment));
    }

    public override void StopBlocking()
    {
        IBlocker blockingEquipment = equipmentManager.GetBlockingEquipment();

        StopDefendAnimation(blockingEquipment);
    }

    protected override void SetStats()
    {
        Debug.Log("setting");
        stats = GetComponent<PlayerStats>();
    }


}
