using UnityEngine;

namespace CodeBase.UnitS.AI
{
    public class IdleState : IUnitState
    {
        private UnitAnimationPlayer unitAnimationPlayer;
        private UnitAi unitAi;
        public IdleState(UnitAnimationPlayer _unitAnimationPlayer,UnitAi _unitAi)
        {
            unitAnimationPlayer = _unitAnimationPlayer;
            unitAi = _unitAi;
        }

        public void EnterState()
        {
            unitAnimationPlayer.PlayIdleAnimation();
        }

        public void Excute()
        {
            unitAnimationPlayer.PlayIdleAnimation();
            if(unitAi.FindTarget())
                unitAi.SwitchState(new FollowingState(unitAi, unitAnimationPlayer));
        }

        public void ExitState()
        {
        }
    }
}

