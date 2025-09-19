using CodeBase;
using CodeBase.UnitS.AI;

public class NoAttack : IAttackBehaviourStrategy
{
    public void Attack(UnitAiController aiController)
    {
        aiController.visualPlayer.unitAnimationPlayer.PlayIdleAnimation();
    }
}
