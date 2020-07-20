using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerCombat : Combat
{

    public Animator animator;
    PlayerMotor motor;
    PlayerManager playerManager;
    Weapon equippedWeapon;
    GameObject instWeapon;

    // Use this for initialization
    void Start()
    {
        playerManager = PlayerManager.instance;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!animationLocked && playerManager.equippedWeapon != null)
                Attack();
        }
    }

    void ResumeMoving()
    {
        motor.EnableMoving();
    }

    public override void Attack()
    {
        instWeapon = playerManager.GetInstWeapon();
        Debug.Log("Atacking with " + playerManager.equippedWeapon);

        motor.DisableMoving();
        motor.FaceMouse();

        StartCoroutine(PlayAttackAnimation("Attack", "Attack_punch", animator, instWeapon, ResumeMoving));
    }

    void HitTarget(Collider entity)
    {
        Debug.Log("entity recieved in the combat controller as " + entity);
    }
}
