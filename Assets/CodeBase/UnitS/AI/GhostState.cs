using UnityEngine;

namespace CodeBase.UnitS.AI
{
    public class GhostState : IUnitState
    {
        private UnitAnimationPlayer unitAnimationPlayer;
        private UnitAi unitAi;
        public GhostState(UnitAnimationPlayer _unitAnimationPlayer,UnitAi _unitAi)
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
        }

        public void ExitState()
        {
            Debug.LogWarning($"ImNot Idling !");
        }
    }
}