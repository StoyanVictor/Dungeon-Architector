using CodeBase.EnemyHero;
using UnityEngine;
using UnityEngine.AI;
public class UnitAiBussinesLogic : MonoBehaviour
{
    [SerializeField] private float attackrange;
    [SerializeField] private float range;
    [SerializeField] private Transform currentTarget;

    public ProjectilePool projectilePool;
    
    public NavMeshAgent agent;

    public UnitHealth unitHealth;

    public float GetAttackRange() => attackrange;
    public float GetFoundRange () => range;
    public Transform GetCurrentTarget() => currentTarget;
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
        print("Im working");
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
}