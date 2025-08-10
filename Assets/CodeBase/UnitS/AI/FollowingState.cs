using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.UnitS.AI
{
    public class FollowingState : IUnitState
    {
        private UnitAi unitAi;
        
        public FollowingState(UnitAi ai)
        {
            unitAi = ai;
        }

        public void EnterState()
        {
            Debug.LogWarning("Im Following");
        }

        public void Excute()
        {
            if (unitAi.FindTarget() && !unitAi.CheckForAttackRange())
            {
                unitAi.Move();
            }
            else if(unitAi.CheckForAttackRange())
                unitAi.SwitchState(new AttackState(unitAi));
        }

        public void ExitState()
        {
        }
    }
}