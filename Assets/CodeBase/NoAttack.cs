using CodeBase;
using CodeBase.UnitS.AI;

public class NoAttack : IAttackBehaviourStrategy
{
    public void Attack(UnitAi ai)
    {
        ai.unitAnimationPlayer.PlayIdleAnimation();
    }
}
