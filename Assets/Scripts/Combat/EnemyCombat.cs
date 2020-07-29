using UnityEngine;
using System.Collections;

public class EnemyCombat : Combat
{
    EnemyMotor motor;


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected override void SetStats()
    {
        stats = GetComponent<CharacterStats>();

    }
}
