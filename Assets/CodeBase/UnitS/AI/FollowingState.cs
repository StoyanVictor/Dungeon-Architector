using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.UnitS.AI
{
    public class FollowingState : IUnitState
    {
        private UnitAi unitAi;
        private UnitAnimationPlayer unitAnimationPlayer;

        public FollowingState(UnitAi ai, UnitAnimationPlayer _unitAnimationPlayer)
        {
            unitAnimationPlayer = _unitAnimationPlayer;
            unitAi = ai;
        }

        public void EnterState()
        {
        }

        public void Excute()
        {
            if(!unitAi.FindTarget())
                unitAi.SwitchState(new IdleState(unitAnimationPlayer,unitAi));
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