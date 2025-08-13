using CodeBase.EnemyHero;
using UnityEngine;

public abstract class OneTargetTrapBase : MonoBehaviour
{
    [SerializeField] private float attackRange;
    private Transform currentTarget;

    public bool FindTarget()
    {
        var objects = Physics.OverlapSphere(transform.position, attackRange);
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

    public Transform GetCurrentTarget() => currentTarget;
    
    
}