using CodeBase.EnemyHero;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MultiTargetTrapBase<T> : MonoBehaviour where T : Component,ITrapEffect
{
    public float effectRange;
    
    public bool EffectUsing()
    {
        var objects = Physics.OverlapSphere(transform.position, effectRange);
        foreach (var obj in objects)
        {
            if (obj.TryGetComponent(out EnemyHeroAiBase unitAi))
            {
                unitAi.AddComponent<T>().StartEffect(5,5);
                return true;
            }
        }
        return false;
    }
    
}