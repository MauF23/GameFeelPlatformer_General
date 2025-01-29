using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerEnemy : AnimationManager
{
    [Header("AnimationManagerEnemy")]
    public KnightAgent knightAgent;

    void AnimEventEndAttackState()
    {
        knightAgent?.ReturnToPreviousState();
    }
}
