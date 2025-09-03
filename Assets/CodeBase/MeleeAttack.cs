using CodeBase;
using CodeBase.UnitS.AI;

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