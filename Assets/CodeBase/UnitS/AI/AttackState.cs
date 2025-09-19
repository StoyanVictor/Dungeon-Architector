using UnityEngine;

namespace CodeBase.UnitS.AI
{
    public class AttackState : IUnitState
    {
        private UnitAiController _unitAiController;
        
        public AttackState(UnitAiController aiController)
        {
            _unitAiController = aiController;
        }
        public void EnterState()
        {
        }

        public void Excute()
        {
            if(_unitAiController.aiLogic.GetCurrentTarget() == null)
                _unitAiController.SwitchState(new IdleState(_unitAiController.visualPlayer.unitAnimationPlayer,_unitAiController));
            if (_unitAiController.aiLogic.CheckForAttackRange())
            {
                _unitAiController.Attack();
            }
            else if(_unitAiController.aiLogic.FindTarget() && !_unitAiController.aiLogic.CheckForAttackRange())
                _unitAiController.SwitchState(new FollowingState(_unitAiController,_unitAiController.visualPlayer.unitAnimationPlayer));
        }

        public void ExitState()
        {
        }
    }
}