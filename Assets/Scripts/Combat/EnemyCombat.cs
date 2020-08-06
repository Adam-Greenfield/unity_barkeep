using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyController))]
[RequireComponent(typeof(EnemyMotor))]
public class EnemyCombat : Combat
{
    EnemyController controller;
    EnemyMotor motor;
    public GOEquipmentSlot[] gOEquipmentSlots;
    Weapon weapon;
    GameObject instWeapon;


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        EnemyController controller = GetComponent<EnemyController>();
        EnemyMotor motor = GetComponent<EnemyMotor>();
        weapon = controller.weapon;
        instWeapon = controller.instWeapon;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack()
    {
        Debug.Log("ememy attacking");
        motor.DisableMoving();

        StartCoroutine(PlayAttackAnimation(weapon, animator, instWeapon, ResumeMoving));
    }

    void ResumeMoving()
    {
        motor.EnableMoving();
    }

    protected override void SetStats()
    {
        stats = GetComponent<CharacterStats>();

    }
}
