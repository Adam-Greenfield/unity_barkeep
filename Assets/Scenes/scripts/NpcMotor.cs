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

    // Start is called before the first frame update
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(goal.transform.position);
        Debug.Log(transform.position);

        agent.SetDestination(GameObject.Find("Chair").transform.position); 
    }
}
