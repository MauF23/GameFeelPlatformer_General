using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class KnightAgent : MonoBehaviour
{
    public KnightAgentStateEnum knightState;
    private KnightAgentStateEnum previousKnightState;

    public float idleSpeed, aggroSpeed, searchRadius;
    public float arriveDistance, playerDetectionDistance;

    public AnimationManager animationManager;   
    public NavMeshAgent agent;
    public Transform player;

    void Start()
    {
        UpdateState(KnightAgentStateEnum.Idle);  
    }

	void Update()
	{
        if(knightState == KnightAgentStateEnum.Attack)
        {
            return;
        }

		if (ArrivedToDestination())
		{
            if (WithinPlayersReach(arriveDistance))
            {
                UpdateState(KnightAgentStateEnum.Attack);
            }
			else if (WithinPlayersReach(playerDetectionDistance))
            {
				UpdateState(KnightAgentStateEnum.Aggro);
			}
		}
        //else if(knightState != KnightAgentStateEnum.Idle)
        //{
        //    UpdateState(KnightAgentStateEnum.Idle);
        //}
        if (WithinPlayersReach(playerDetectionDistance) && knightState == KnightAgentStateEnum.Idle)
        {
            UpdateState(KnightAgentStateEnum.Aggro);
        }

        animationManager?.SetAnimMovement(agent.speed);

	}

	void UpdateState(KnightAgentStateEnum newState)
    {
        previousKnightState = knightState;
		knightState = newState;

        switch (knightState) 
        {
            case KnightAgentStateEnum.Idle:
                agent.SetDestination(GetRandomDestination());
				agent.speed = idleSpeed;
				break;

			case KnightAgentStateEnum.Aggro:
                agent.SetDestination(player.position);
                agent.speed = aggroSpeed;
				break;

			case KnightAgentStateEnum.Attack:
                agent.speed = 0;
                animationManager.SetAttack();
				break;
		}
    }

    public void ReturnToPreviousState()
    {
        UpdateState(previousKnightState);
    }

    public bool ArrivedToDestination()
    {
        return Vector3.Distance(transform.position, agent.destination) <= arriveDistance;
    }

    public bool WithinPlayersReach(float distance)
    {
		return Vector3.Distance(transform.position, player.position) <= distance;
	}

	public Vector3 GetRandomDestination()
    {
		Vector3 randomDirection = Random.insideUnitSphere * searchRadius;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, searchRadius, 1);
        return hit.position;    
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, searchRadius);

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, playerDetectionDistance);

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, arriveDistance);

	}

}
