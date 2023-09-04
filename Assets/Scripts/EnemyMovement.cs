using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public GameObject target;

    int m_CurrentWaypointIndex;
    float m_followDistance = 20f;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if(m_followDistance > (navMeshAgent.transform.position - target.transform.position).sqrMagnitude)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
        else if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            
        }
    }
}
