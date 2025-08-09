using System;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.UnitS.AI
{
    public class UnitAi : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        private UnitAnimationPlayer unitAnimationPlayer;
        private IUnitState currentState;
        public Transform pointToGo;
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
            agent.SetDestination(pointToGo.position);

        }

        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                SwitchState(new FollowingState(this,unitAnimationPlayer));
            }

            currentState.Excute();
            
        }

        private void Awake()
        {
            unitAnimationPlayer = new UnitAnimationPlayer(animator);
        }

        private void Start()
        {
            SwitchState(new IdleState(unitAnimationPlayer));
        }
    }
}