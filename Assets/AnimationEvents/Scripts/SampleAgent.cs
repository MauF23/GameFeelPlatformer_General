using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.UI;
using UnityEngine.AI;

public class SampleAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    public int currentPatrolPoint;
    public Transform currentDestination;
    public float distance;

    void Start()
    {
        currentPatrolPoint = 0;
        currentDestination = patrolPoints[0];
        agent.SetDestination(currentDestination.position);
    }

    void Update()
    {
        if (HasReachedDestination())
        {
            UpdateDestination();
        }
    }

    public bool HasReachedDestination()
    {
        distance = Vector3.Distance(transform.position, currentDestination.position);
        return distance <= agent.stoppingDistance;
    }

    public void UpdateDestination()
    {
        currentPatrolPoint++;
        if(currentPatrolPoint > patrolPoints.Length)
        {
            currentPatrolPoint = 0;
        }

        currentDestination = patrolPoints[currentPatrolPoint];
        agent.SetDestination(currentDestination.position);
    }
}
