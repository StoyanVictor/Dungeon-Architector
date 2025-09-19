using CodeBase;
using CodeBase.UnitS.AI;
using UnityEngine.UI;

public class MeleeAttack : IAttackBehaviourStrategy
{
    public void Attack(UnitAiController aiController)
    {
        if (aiController.aiLogic.CheckForAttackRange())
        { 
            aiController.aiLogic.LookAtTarget();
            aiController.visualPlayer.unitAnimationPlayer.PlayAttackAnimation();
        }
    }
}