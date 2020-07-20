using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerCombat : Combat
{

    PlayerMotor motor;
    PlayerManager playerManager;



    // Use this for initialization
    void Start()
    {
        playerManager = PlayerManager.instance;
        motor = GetComponent<PlayerMotor>();
        equippedWeapon = playerManager.GetWeapon();
        InstantiateWeapon(equippedWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!animationLocked && equippedWeapon != null)
                Attack();
        }
    }

    void ResumeMoving()
    {
        motor.EnableMoving();
    }

    public override void Attack()
    {
        //every time we attack, we need to check which weapon is equipped
        Debug.Log("Atacking with " + equippedWeapon);

        motor.DisableMoving();
        motor.FaceMouse();

        StartCoroutine(PlayAttackAnimation("Attack", "Attack_punch", animator, instWeapon, ResumeMoving));
    }


}
