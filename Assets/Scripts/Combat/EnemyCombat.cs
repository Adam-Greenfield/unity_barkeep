using UnityEngine;
using System.Collections;

public class EnemyCombat : Combat
{
    EnemyMotor motor;


    // Use this for initialization
    void Start()
    {
        //instantiate the weapon
        InstantiateWeapon(equippedWeapon);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

}
