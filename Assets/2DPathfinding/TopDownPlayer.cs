using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rigidbody;
    public Animator animator;

    private Vector2 movementVector;
	private Vector2 lastMovementVector;

    private const string xAxis = "Horizontal";
    private const string yAxis = "Vertical";
	private const string ANIM_MOVE_SPEED = "moveSpeed";
	private const string ANIM_MOVE_DIRECTIONX = "moveDirectionX";
	private const string ANIM_MOVE_DIRECTIONY = "moveDirectionY";


	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = new Vector2(Input.GetAxis(xAxis), Input.GetAxis(yAxis)).normalized;
	}

	private void LateUpdate()
	{
		rigidbody.velocity = movementVector * movementSpeed;
		UpdateAnimator();
	}
	private void UpdateAnimator()
	{
		if (movementVector.sqrMagnitude > 0)
		{
			lastMovementVector = rigidbody.velocity.normalized;
		}

		animator.SetFloat(ANIM_MOVE_SPEED, rigidbody.velocity.sqrMagnitude);
		animator.SetFloat(ANIM_MOVE_DIRECTIONX, lastMovementVector.x);
		animator.SetFloat(ANIM_MOVE_DIRECTIONY, lastMovementVector.y);
	}
}
