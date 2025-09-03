using CodeBase.EnemyHero;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.UnitS.AI
{
    public class UnitAi : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        public NavMeshAgent agent;
        [SerializeField] private float range;
        [SerializeField] private float attackrange;
        [SerializeField] private Collider _collider;
        [SerializeField] private FabricCreatingSfxPlayer fabricCreatingSfxPlayer;
        [SerializeField] private UnitSpawnVfxPlayer unitSpawnVfxPlayer;
        public Transform currentTarget;
        public UnitAnimationPlayer unitAnimationPlayer;
        private IUnitState currentState;
        public bool enableGizmos;

        public IAttackBehaviourStrategy attackStrategy;
        public IMoveBehaviourStrategy moveStrategy;
        
        public Transform GetCurrentTarget() => currentTarget;

        public void EnableCollider() => _collider.enabled = true;
        public void PlaySpawnVfx() => unitSpawnVfxPlayer.PlaySpawnVfx();
        public void PlaySpawnOneShot() => fabricCreatingSfxPlayer.PlayCreateSFX();

        public void StartWorkWithRealUnit()
        {
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
            moveStrategy.Move(this);
        }
        public  void Attack()
        {
            attackStrategy.Attack(this);
        }
        public void LookAtTarget()
        {
            if (currentTarget != null)
            {
                Vector3 lookPos = GetCurrentTarget().position - transform.position;
                lookPos.y = 0;
                transform.rotation = Quaternion.LookRotation(lookPos);
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
            if (enableGizmos)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(transform.position,range);
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(transform.position,attackrange);
            }

        }

        private void Awake()
        {
            unitAnimationPlayer = new UnitAnimationPlayer(animator);
            SwitchState(new GhostState(unitAnimationPlayer,this));
            Observable.EveryUpdate().Subscribe(_ => currentState.Excute()).AddTo(this);
        }
    }
}