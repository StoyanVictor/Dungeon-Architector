using CodeBase.UnitS.AI;

public class SimpleMove : IMoveBehaviourStrategy
{
    public void Move(UnitAiController aiController)
    {
        if (aiController.aiLogic.FindTarget() && !aiController.aiLogic.CheckForAttackRange())
        {
            aiController.visualPlayer.unitAnimationPlayer.PlayWalkAnimation();
            aiController.aiLogic.agent.SetDestination(aiController.aiLogic.GetCurrentTarget().transform.position);
        }
        else
        {
            aiController.aiLogic.FindTarget();
            return;
        }
    }
}