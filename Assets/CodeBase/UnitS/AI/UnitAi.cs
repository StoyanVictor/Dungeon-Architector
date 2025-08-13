using System;
using CodeBase.EnemyHero;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.UnitS.AI
{
    public class UnitAi : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private float range;
        [SerializeField] private float attackrange;
        public Transform currentTarget;
        public UnitAnimationPlayer unitAnimationPlayer;
        private IUnitState currentState;

        public Transform GetCurrentTarget() => currentTarget;
        public void SwitchState(IUnitState state)
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
        public void Move()
        {
            if (FindTarget() && !CheckForAttackRange())
            {
                unitAnimationPlayer.PlayWalkAnimation();
                agent.SetDestination(GetCurrentTarget().transform.position);
            }
            else
            {
                return;
            }
        }
        public  void Attack()
        {
            if (CheckForAttackRange())
            {
                unitAnimationPlayer.PlayAttackAnimation();
            }
        }
        public bool CheckForAttackRange()
        {
            var objects = Physics.OverlapSphere(transform.position, attackrange);
            foreach (var obj in objects)
            {
                if (obj.TryGetComponent(out EnemyHeroAiBase unitAi))
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
                if (obj.TryGetComponent(out EnemyHeroAiBase unitAi))
                {
                    currentTarget = obj.transform;
                    return true;
                }
            }
            return false;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position,range);
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(transform.position,attackrange);
            
        }
        private void Update()
        {
            currentState.Excute();
        }

        private void Awake()
        {
            unitAnimationPlayer = new UnitAnimationPlayer(animator);
        }

        private void Start()
        {
            SwitchState(new IdleState(unitAnimationPlayer,this));
        }
    }
}