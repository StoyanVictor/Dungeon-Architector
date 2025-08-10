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
            Debug.LogWarning("Im Idle Boy!");
            unitAnimationPlayer.PlayIdleAnimation();
        }

        public void Excute()
        {
            unitAnimationPlayer.PlayIdleAnimation();
            if(unitAi.FindTarget())
                unitAi.SwitchState(new FollowingState(unitAi));
        }

        public void ExitState()
        {
            Debug.LogWarning($"ImNot Idling !");
        }
    }
}