using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    [SerializeField]
    public Transform[] target;

    GameObject[] meetingChairs;

    NavMeshAgent navMeshAgent;

    TextMesh textMesh;

    public bool isBoss = false;

    public int worker_id = 0;

    private void Awake()
    {
        meetingChairs = GameObject.FindGameObjectsWithTag("MeetingSeats");

        if (!isBoss)
            DecideMeetingChair();
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        textMesh = GetComponentInChildren<TextMesh>();
        
        if (!isBoss)
            textMesh.text = "Worker: " + worker_id;
        else
            textMesh.text = "Boss: " + worker_id;

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

    private void DecideMeetingChair()
    {
        Transform meetingChair = meetingChairs[0].transform;

        if (meetingChairs[0].GetComponent<Chair>().isTaken)
        {
            for (int i = 1; i < meetingChairs.Length; i++)
            {
                if (!meetingChairs[i].GetComponent<Chair>().isTaken)
                {
                    meetingChairs[i].GetComponent<Chair>().isTaken = true;
                    meetingChair = meetingChairs[i].transform;
                    break;
                }
            }
        }

        for (int i = 0; i < target.Length; i++)
        {
            if (target[i].name == "Meeting")
            {
                target[i] = meetingChair;
            }
        }

        meetingChair.GetComponent<Chair>().isTaken = true;
    }

    // Update is called once per frame
    void Update()
    {
        Destination();
    }
}
