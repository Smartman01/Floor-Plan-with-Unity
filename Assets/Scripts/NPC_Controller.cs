using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    [SerializeField]
    Transform target;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        Destination();
    }

    private void Destination()
    {
        Vector3 targetDest = target.transform.position;
        navMeshAgent.SetDestination(targetDest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
