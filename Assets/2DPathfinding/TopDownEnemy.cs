using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TopDownEnemy : MonoBehaviour
{

    public Animator animator;
    public AIPath agent2D;
    private float moveSpeed;
    private Vector2 lastMoveDirection;

    private const string ANIM_MOVE_SPEED = "moveSpeed";
    private const string ANIM_MOVE_DIRECTIONX = "moveDirectionX";
    private const string ANIM_MOVE_DIRECTIONY = "moveDirectionY";

	void Start()
    {
        
    }


    void Update()
    {
        UpdateAnimator();
	}

    private void UpdateAnimator()
    {
        moveSpeed = agent2D.velocity.sqrMagnitude;
        if(moveSpeed > 0)
        {
            lastMoveDirection = agent2D.velocity.normalized;
        }

        animator.SetFloat(ANIM_MOVE_SPEED, moveSpeed);  
        animator.SetFloat(ANIM_MOVE_DIRECTIONX, lastMoveDirection.x);
        animator.SetFloat(ANIM_MOVE_DIRECTIONY, lastMoveDirection.y);
	}
}
