using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPC_Movement_Behaviour : MonoBehaviour
{
    public Transform trans_npcFirstListWP;
    public bool b_raceStarted = true;
    public float f_npcSpeed;
    private Transform trans_nextWayPoint;
    private NavMeshAgent nav_npcAgent;

    void Start()
    {
        nav_npcAgent = GetComponent<NavMeshAgent>();
        nav_npcAgent.speed = f_npcSpeed;
    }

    void Update()
    {
        if(b_raceStarted == true)
        {
            nav_npcAgent.SetDestination(trans_npcFirstListWP.position);
            b_raceStarted = false;
        }
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.tag == "Waypoints")
        {
            trans_nextWayPoint = _collider.gameObject.GetComponent<Waypoints>().nextPoint;
            nav_npcAgent.SetDestination(trans_nextWayPoint.position);
        }
    }
}