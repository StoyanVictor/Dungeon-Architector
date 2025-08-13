using CodeBase.EnemyHero;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MultiTargetTrapBase : MonoBehaviour
{
    public float effectRange;
    
    public bool EffectUsing()
    {
        var objects = Physics.OverlapSphere(transform.position, effectRange);
        foreach (var obj in objects)
        {
            if (obj.TryGetComponent(out EnemyHeroAiBase unitAi))
            {
                obj.AddComponent<PoisonEffect>().StartPoison(5,5);
                return true;
            }
        }
        return false;
    }
    
}