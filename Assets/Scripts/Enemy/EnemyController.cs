using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(EnemyCombat))]
public class EnemyController : MonoBehaviour, IInstantiateEquipment
{

    public float lookRadius = 10f;
    public GOEquipmentSlot[] gOEquipmentSlots;
    public Weapon weapon;

    [System.NonSerialized]
    public GameObject instWeapon;

    [System.NonSerialized]
    NavMeshAgent agent;

    Transform target;
    EnemyCombat combat;
    PlayerManager playerManager;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem, GameObject instEquipment);
    public OnEquipmentChanged onEquipmentChangedCallback;

    // Use this for initialization
    void Start()
    {
        playerManager = PlayerManager.instance;
        agent = GetComponent<NavMeshAgent>();
        target = playerManager.player.transform;
        combat = GetComponent<EnemyCombat>();
        if (weapon != null)
        {
            instWeapon = InstantiateEquipmentOnCharacter(weapon);
            if(onEquipmentChangedCallback != null)
                onEquipmentChangedCallback.Invoke(weapon, null, null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (combat.animationLocked)
            return;

        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
                //to attack, start animation, have box collider on attacking part, register a hit and cause animation on enemy
                //playerManager
                combat.Attack();

            }

        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public GameObject InstantiateEquipmentOnCharacter(Equipment equipment)
    {
        Debug.Log("Creating equipment as " + equipment.name);
        GameObject instEquipment = null;

        if (equipment.prefab != null)
        {
            GOEquipmentSlot equipSlot = gOEquipmentSlots.FirstOrDefault(x => x.equipSlot == equipment.equipSlot);

            instEquipment = Instantiate(equipment.prefab);
            instEquipment.transform.SetParent(equipSlot.gObodyPart.transform, false);

            return instEquipment;
        }

        return null;
    }
}
