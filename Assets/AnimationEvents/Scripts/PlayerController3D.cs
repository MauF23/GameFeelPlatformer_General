using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
	private Vector3 movementVector;
    private Vector3 relativeToCameraDirection, relativeMovementVector;
    public float movementSpeed, rotationSpeed;
	public bool canMove = true;

    private const float GROUND_SPHERE_RADIUS = 0.5f;
    private const float GRAVITY = -20;

	public LayerMask groundLayer;
    public Transform groundPoint;
	public Rigidbody rigidbody;
    public Camera playerCamera;
    public AnimationManager animationManager;
    public bool canAttack = true;
    private bool grounded;

    void Start()
    {
        canMove = true;
	}

	private void Update()
	{
        grounded = Grounded();

		if (grounded)
        {
			movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			Attack();
		}
	}

	void FixedUpdate()
    {
		if (grounded)
        {
			Debug.Log("Grounded");

			if (!canMove)
            {
                return;
            }

			rigidbody.velocity = Movement();

			if (Movement() != Vector3.zero)
            {
                Rotation();
            }
            animationManager?.SetAnimMovement(Movement().sqrMagnitude);
		}
        else
        {
            Debug.Log("NotGrounded");
			rigidbody.velocity += new Vector3(0, GRAVITY, 0);
		}
    }

    Vector3 Movement()
    {
		relativeToCameraDirection = RelativeCameraDirection(movementVector);
		return relativeMovementVector = relativeToCameraDirection * movementSpeed;
    }

    void Rotation()
    {
        Vector3 v = RelativeCameraDirection(movementVector);
		Quaternion targetRotation = Quaternion.LookRotation(relativeMovementVector);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
	}

    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            animationManager?.SetAttack();
        }
    }

    public void ToggleAttack(bool attackValue)
    {
        canAttack = attackValue;
    }

    bool Grounded()
    {
        Collider[] colliders = Physics.OverlapSphere(groundPoint.transform.position, GROUND_SPHERE_RADIUS, groundLayer);

        for(int i = 0; i < colliders.Length; i++)
        {
            Debug.Log("<color=green> layerGrounded: " + colliders[i].gameObject.name + "</color>");
        }

        return (colliders.Length > 0) ;
    }

    Vector3 RelativeCameraDirection(Vector3 referenceVector)
    {
		float cameraForward = playerCamera.transform.eulerAngles.y;
		return relativeToCameraDirection = (Quaternion.Euler(0, cameraForward, 0) * referenceVector).normalized;
	}

    public void ToggleMovement(bool canMove)
    {

        if (!canMove)
        {
            rigidbody.velocity = Vector3.zero;  
        }
        this.canMove = canMove;
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundPoint.transform.position, GROUND_SPHERE_RADIUS);
	}

}
