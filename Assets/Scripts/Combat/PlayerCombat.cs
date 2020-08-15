﻿using UnityEngine;
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
            Debug.Log("Weapon is " + weapon);
            if(!animationLocked && weapon != null)
                Attack();
        }

        if (Input.GetButtonDown("Block"))
        {
            Debug.Log("blocking with something, presumably");
            //check player manager to see if there's shield equipped
            //if not, block with weapon
            if (!animationLocked && weapon != null)
                Attack();
        }
    }

    void UpdateWeapon(Equipment newWeapon, Equipment oldItem, GameObject newInstWeapon)
    {
        weapon = (Weapon)newWeapon;
        instWeapon = newInstWeapon;
    }

    void ResumeMoving()
    {
        motor.EnableMoving();
    }

    public override void Attack()
    {
        motor.DisableMoving();
        motor.FaceMouse();

        StartCoroutine(PlayAttackAnimation(weapon, animator, instWeapon, ResumeMoving));
    }

    public override void Block()
    {
        motor.DisableMoving();
        motor.FaceMouse();

        StartCoroutine(PlayDefendAnimation(weapon, animator, instWeapon, ResumeMoving));
    }

    protected override void SetStats()
    {
        Debug.Log("setting");
        stats = GetComponent<PlayerStats>();
    }


}
