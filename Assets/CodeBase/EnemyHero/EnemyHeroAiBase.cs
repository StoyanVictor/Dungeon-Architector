using System;
using CodeBase.UnitS.AI;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.EnemyHero
{
    public abstract class EnemyHeroAiBase : MonoBehaviour
    {
        protected IEnemyHeroState currentState;
        public NavMeshAgent agent;
        public Transform currentTarget;
        public Transform maintTarget;
        public EnemyHeroAnimationPlayer animationPlayer;
        public Animator animator;
        public float range;
        public float attackrange;

        public Transform GetCurrentTarget() => currentTarget;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position,range);
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(transform.position,attackrange);
            
        }

        private void Awake()
        {
            maintTarget = GameObject.FindWithTag("MainGoal").transform;
            animationPlayer = new EnemyHeroAnimationPlayer(animator);
            SwitchState(new EnemyHeroChaseState(this));
        }
        
        public bool CheckForAttackRange()
        {
            var objects = Physics.OverlapSphere(transform.position, attackrange);
            foreach (var obj in objects)
            {
                if (obj.TryGetComponent(out UnitHealth unitAi)) 
                {
                    return true;
                }
            }
            return false;
        }
        public bool FindTarget()
        {
            var objects = Physics.OverlapSphere(transform.position, range);
            foreach (var obj in objects)
            {
                if (obj.TryGetComponent(out UnitHealth unitAi))
                {
                    currentTarget = obj.transform;
                    return true;
                }
            }
            return false;
        }
        
        public void SwitchState(IEnemyHeroState state)
        {
            if (currentState != null)
            {
                currentState.ExitState();
                currentState = state;
                currentState?.EnterState();
            }
            else
            {
                currentState = state;
                currentState.EnterState();
            }
        }
        public abstract void Move();
        public abstract void Attack();
    }
}