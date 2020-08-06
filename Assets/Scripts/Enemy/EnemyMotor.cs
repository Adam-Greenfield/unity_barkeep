using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMotor : MonoBehaviour
{

    public LayerMask movementMask;
    public GameObject goal;

    NavMeshAgent agent;
    Vector3 target;

    // Start is called before the first frame update
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        target = goal.transform.position;
        agent.SetDestination(target); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisableMoving()
    {
        agent.isStopped = true;
        agent.ResetPath();
        agent.velocity = Vector3.zero;
    }

    public void EnableMoving()
    {
        agent.isStopped = false;
    }
}
