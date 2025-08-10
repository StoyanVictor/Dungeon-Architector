using UnityEngine;

namespace CodeBase.UnitS.AI
{
    public class UnitAnimationPlayer
    {
        private const string IDLE = "Idle";
        private const string WALK = "Walk";
        private const string ATTACK = "Attack";
        private Animator animator;
        
        public UnitAnimationPlayer(Animator _animator)
        {
            animator = _animator;
        }

        public void PlayIdleAnimation()
        {
            animator.Play(IDLE);
        }
        public void PlayWalkAnimation()
        {
            animator.Play(WALK);
        }
        public void PlayAttackAnimation()
        {
            animator.Play(ATTACK);
        }
    }
}