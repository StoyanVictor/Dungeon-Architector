using UnityEngine;

namespace CodeBase.UnitS.AI
{
    public class IdleState : IUnitState
    {
        private UnitAnimationPlayer unitAnimationPlayer;
        private UnitAiController _unitAiController;
        public IdleState(UnitAnimationPlayer _unitAnimationPlayer,UnitAiController unitAiController)
        {
            unitAnimationPlayer = _unitAnimationPlayer;
            _unitAiController = unitAiController;
        }

        public void EnterState()
        {
            Debug.Log("Hi");
            unitAnimationPlayer.PlayIdleAnimation();
        }

        public void Excute()
        {
            unitAnimationPlayer.PlayIdleAnimation();
            if(_unitAiController.aiLogic.FindTarget())
                _unitAiController.SwitchState(new FollowingState(_unitAiController, unitAnimationPlayer));
        }

        public void ExitState()
        {
        }
    }
}

