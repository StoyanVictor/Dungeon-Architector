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
        [SerializeField] private Collider _collider;
        [SerializeField] private FabricCreatingSfxPlayer fabricCreatingSfxPlayer;
        [SerializeField] private UnitSpawnVfxPlayer unitSpawnVfxPlayer;
        public Transform currentTarget;
        public UnitAnimationPlayer unitAnimationPlayer;
        private IUnitState currentState;

        public Transform GetCurrentTarget() => currentTarget;

        public void EnableCollider() => _collider.enabled = true;
        public void PlaySpawnVfx() => unitSpawnVfxPlayer.PlaySpawnVfx();
        public void PlaySpawnOneShot() => fabricCreatingSfxPlayer.PlayCreateSFX();

        public void StartWorkWithRealUnit()
        {
            Debug.LogWarning($"Hi im trying to switch state to idle");
            SwitchState(new IdleState(unitAnimationPlayer,this));
        }

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
                transform.LookAt(GetCurrentTarget());
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
            Debug.LogWarning($"Im trying to find target");
            Debug.LogWarning($"{currentState}");

            currentState.Excute();
        }

        private void Awake()
        {
            unitAnimationPlayer = new UnitAnimationPlayer(animator);
            SwitchState(new GhostState(unitAnimationPlayer,this));
        }
    }
}