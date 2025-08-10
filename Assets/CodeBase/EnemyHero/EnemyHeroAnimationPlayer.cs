using UnityEngine;

public class EnemyHeroAnimationPlayer
{
    private const string IDLE = "Idle";
    private const string WALK = "Walk";
    private const string ATTACK = "Attack";
    private Animator animator;
        
    public EnemyHeroAnimationPlayer(Animator _animator)
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