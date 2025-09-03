using CodeBase.UnitS.AI;

public class SimpleMove : IMoveBehaviourStrategy
{
    public void Move(UnitAi ai)
    {
        if (ai.FindTarget() && !ai.CheckForAttackRange())
        {
            ai.unitAnimationPlayer.PlayWalkAnimation();
            ai.agent.SetDestination(ai.GetCurrentTarget().transform.position);
        }
        else
        {
            return;
        }
    }
}