using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public PlayerController3D playerController;
    public Sword sword;


    protected const string MOVEMENT_SPEED = "MovementSpeed";
	protected const string ATTACK = "Attack";
	protected const string HIT = "Hit";
	protected const string DEATH = "Death";

    public void SetAnimMovement(float movementSpeed)
    {
        animator.SetFloat(MOVEMENT_SPEED, movementSpeed);
    }

	public void SetAnimHit()
	{
		animator.SetTrigger(HIT);
	}

    public void SetAttack()
    {
        animator.SetTrigger(ATTACK);
    }

    public void SetDeath()
    {
        animator.SetTrigger(DEATH); 
    }

	#region AnimationEvents
	public void AnimEventEnableSwordHitbox()
    {
        sword?.EnableHitbox();
	}

	public void AnimEventDisableSwordHitbox()
	{
		sword?.DisableHitbox();
	}

    public void AnimEventEnableAttack()
    {
        playerController.ToggleAttack(true);
    }

    public void AnimEventDisableAttack()
    {
        playerController.ToggleAttack(false);
    }

    public void BlockAttack(int hitboxActive)
    {
        int pseudoBool = Mathf.Clamp(hitboxActive, 0, 1);

        bool blockAttack = false;

        if(pseudoBool >= 1)
        {
            blockAttack = true;
        }
        else
        {
            blockAttack = false;
        }

        playerController.ToggleAttack(blockAttack);
    }
	#endregion

    public void DebugFromAnimatorManager()
    {
        Debug.Log("AnimatorManagerSaysHello");
    }
}
