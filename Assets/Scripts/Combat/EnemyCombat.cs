using UnityEngine;
using System.Collections;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyController))]
[RequireComponent(typeof(EnemyMotor))]
public class EnemyCombat : Combat
{
    EnemyController controller;
    NavMeshAgent agent;
    Weapon weapon;
    GameObject instWeapon;


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        controller = GetComponent<EnemyController>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack()
    {
        weapon = controller.weapon;
        instWeapon = controller.instWeapon;

        DisableMoving();

        StartCoroutine(PlayAttackAnimation(weapon, instWeapon, ResumeMoving));
    }

    public override void Block()
    {
        throw new System.NotImplementedException();
    }

    public void DisableMoving()
    {
        agent.isStopped = true;
        agent.ResetPath();
        agent.velocity = Vector3.zero;
    }

    void ResumeMoving()
    {
        agent.isStopped = false;
    }

    protected override void SetStats()
    {
        stats = GetComponent<CharacterStats>();

    }

    public override void StopBlocking()
    {
        throw new System.NotImplementedException();
    }
}
