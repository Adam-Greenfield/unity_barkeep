using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class NpcMotor : MonoBehaviour
{

    NavMeshAgent agent;
    public LayerMask movementMask;


    public GameObject goal;
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
}
