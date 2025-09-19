using UniRx;
using UnityEngine;

namespace CodeBase.UnitS.AI
{
    [RequireComponent(typeof(UnitAiVisuals))]
    [RequireComponent(typeof(UnitAiBussinesLogic))]
    public class  UnitAiController : MonoBehaviour
    {
        
        [SerializeField] private Collider _collider;
        
        private IUnitState currentState;
        public bool enableGizmos;

        public IAttackBehaviourStrategy attackStrategy;
        public IMoveBehaviourStrategy moveStrategy;

        public UnitAiVisuals visualPlayer;
        public UnitAiBussinesLogic aiLogic;
        private void EnableCollider() => _collider.enabled = true;

        public void ValidatingUnitEntity()
        {
            EnableCollider();
            visualPlayer.PlaySpawnOneShot();
            visualPlayer.PlaySpawnVfx();
            StartWorkWithRealUnit();
        }

        public void SetGhost()=> SwitchState(new GhostState(visualPlayer.unitAnimationPlayer,this));


        public void StartWorkWithRealUnit()
        {
            currentState = new IdleState(visualPlayer.unitAnimationPlayer, this);
            print(currentState);
        }
        
        public void SwitchState(IUnitState state)
        {
            if (currentState != null)
            {
                currentState.ExitState();
                currentState = state;
                currentState?.EnterState();
                print("IM SWITCHING");
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

        private void Update()
        {
            print(currentState);
        }

        private void OnDrawGizmos()
        {
            if (enableGizmos)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(transform.position,aiLogic.GetFoundRange());
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(transform.position,aiLogic.GetAttackRange());
            }
        }

        private void Start()
        {
            Observable.EveryUpdate().Subscribe(_ => currentState.Excute()).AddTo(this);
        }
    }
}