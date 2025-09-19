using UnityEngine;

namespace CodeBase.UnitS.AI
{
    public class GhostState : IUnitState
    {
        private UnitAnimationPlayer unitAnimationPlayer;
        private UnitAiController _unitAiController;
        public GhostState(UnitAnimationPlayer _unitAnimationPlayer,UnitAiController unitAiController)
        {
            unitAnimationPlayer = _unitAnimationPlayer;
            _unitAiController = unitAiController;
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
        }
    }
}