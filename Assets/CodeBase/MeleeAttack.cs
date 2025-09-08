using CodeBase;
using CodeBase.UnitS.AI;
using UnityEngine.UI;

public class MeleeAttack : IAttackBehaviourStrategy
{
    public void Attack(UnitAi ai)
    {
        if (ai.CheckForAttackRange())
        { 
            ai.LookAtTarget();
            ai.unitAnimationPlayer.PlayAttackAnimation();
        }
    }
}