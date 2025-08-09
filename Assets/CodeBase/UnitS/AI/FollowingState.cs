using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.UnitS.AI
{
    public class FollowingState : IUnitState
    {
        private UnitAi unitAi;
        private UnitAnimationPlayer unitAnimationPlayer;
        
        public FollowingState(UnitAi ai,UnitAnimationPlayer _unitAnimationPlayer)
        {
            unitAi = ai;
            unitAnimationPlayer = _unitAnimationPlayer;
        }

        public void EnterState()
        {
            Debug.LogWarning("Im Following");
        }

        public void Excute()
        {
            unitAi.Move();
            unitAnimationPlayer.PlayWalkAnimation();
        }

        public void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}