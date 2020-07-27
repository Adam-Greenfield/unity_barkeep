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
    void Start()
    {
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Weapon is " + weapon);
            if(!animationLocked && weapon != null)
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
        //every time we attack, we need to check which weapon is equipped
        Debug.Log("Atacking with " + weapon);

        motor.DisableMoving();
        motor.FaceMouse();

        StartCoroutine(PlayAttackAnimation(weapon, animator, instWeapon, ResumeMoving));
    }


}
