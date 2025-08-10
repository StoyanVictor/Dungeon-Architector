using UnityEngine;

namespace CodeBase.UnitS.AI
{
    public class AttackState : IUnitState
    {
        private UnitAi unitAi;
        
        public AttackState(UnitAi ai)
        {
            unitAi = ai;
        }
        public void EnterState()
        {
            Debug.LogWarning("Im attackState");
        }

        public void Excute()
        {
            if (unitAi.CheckForAttackRange())
            {
                unitAi.Attack();
            }
            else if(unitAi.FindTarget() && !unitAi.CheckForAttackRange())
                unitAi.SwitchState(new FollowingState(unitAi));
        }

        public void ExitState()
        {
        }
    }
}