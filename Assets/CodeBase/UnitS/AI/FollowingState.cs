namespace CodeBase.UnitS.AI
{
    public class FollowingState : IUnitState
    {
        private UnitAiController _unitAiController;
        private UnitAnimationPlayer unitAnimationPlayer;

        public FollowingState(UnitAiController aiController, UnitAnimationPlayer _unitAnimationPlayer)
        {
            unitAnimationPlayer = _unitAnimationPlayer;
            _unitAiController = aiController;
        }

        public void EnterState()
        {
        }

        public void Excute()
        {
            if(!_unitAiController.aiLogic.FindTarget())
                _unitAiController.SwitchState(new IdleState(unitAnimationPlayer,_unitAiController));
            if (_unitAiController.aiLogic.FindTarget() && !_unitAiController.aiLogic.CheckForAttackRange())
            {
                _unitAiController.Move();
            }
            else if(_unitAiController.aiLogic.CheckForAttackRange())
                _unitAiController.SwitchState(new AttackState(_unitAiController));
        }

        public void ExitState()
        {
        }
    }
}