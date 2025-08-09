using UnityEngine;

namespace CodeBase.UnitS.AI
{
    public class IdleState : IUnitState
    {
        private UnitAnimationPlayer unitAnimationPlayer;
        public IdleState(UnitAnimationPlayer _unitAnimationPlayer)
        {
            unitAnimationPlayer = _unitAnimationPlayer;
        }

        public void EnterState()
        {
            Debug.LogWarning("Im Idle Boy!");
            unitAnimationPlayer.PlayIdleAnimation();
        }

        public void Excute()
        {
            unitAnimationPlayer.PlayIdleAnimation();
        }

        public void ExitState()
        {
            Debug.LogWarning($"ImNot Idling !");
        }
    }
}