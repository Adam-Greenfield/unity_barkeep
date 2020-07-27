using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IInstantiateEquipment
{

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    public GOEquipmentSlot[] gOEquipmentSlots;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
                //to attack, start animation, have box collider on attacking part, register a hit and cause animation on enemy
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

    public GameObject InstantiateEquipmentOnCharacter(Equipment equipment, int slotIndex)
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
