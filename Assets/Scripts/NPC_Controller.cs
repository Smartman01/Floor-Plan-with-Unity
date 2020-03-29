using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    [SerializeField]
    public Transform[] target;

    NavMeshAgent navMeshAgent;

    TextMesh textMesh;

    public int worker_id = 0;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = "Worker: " + worker_id;

        Destination();
    }

    private void Destination()
    {
        Vector3 targetDest = target[targetLocation()].transform.position;
        navMeshAgent.SetDestination(targetDest);
    }

    private int targetLocation()
    {
        return (int)(Time.realtimeSinceStartup / 60);
    }

    // Update is called once per frame
    void Update()
    {
        Destination();
    }
}
