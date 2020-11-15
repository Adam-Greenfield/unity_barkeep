using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyController))]
public class EnemyStats : CharacterStats
{
    EnemyController enemyController;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        enemyController = GetComponent<EnemyController>();
        enemyController.onEquipmentChangedCallback += OnEquipmentChanged;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
