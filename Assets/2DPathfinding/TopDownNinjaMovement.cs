using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TopDownNinjaMovement : MonoBehaviour
{
    public Animator animator;
    public AIPath agent2D; //el agente 2D
    public Vector2 agentMovement, lastMovementDirection;

    private const string ANIM_MOVEX = "MoveX";
    private const string ANIM_MOVEY = "MoveY";
    private const string ANIM_MOVESPEED = "MoveSpeed";


    void Start()
    {

    }

    void Update()
    {
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        agentMovement = agent2D.velocity.normalized;

        //Actualizar la última dirección si el agente se está moviendo (su magnitud es mayor a cero).
        if(agentMovement.sqrMagnitude > 0)
        {
            lastMovementDirection = agentMovement;
        }

        animator.SetFloat(ANIM_MOVEX, lastMovementDirection.x);
        animator.SetFloat(ANIM_MOVEY, lastMovementDirection.y);
        animator.SetFloat(ANIM_MOVESPEED, agentMovement.sqrMagnitude);
    }
}
