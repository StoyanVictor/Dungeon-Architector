using CodeBase.EnemyHero;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MultiTargetTrapBase<T> : MonoBehaviour where T : Component,ITrapEffect
{
    public float effectRange;
    
    public bool EffectUsing(int duration,int dmg )
    {
        var objects = Physics.OverlapBox(transform.position,transform.localPosition / 2,Quaternion.identity);
        foreach (var obj in objects)
        {
            if (obj.TryGetComponent(out EnemyHeroAiBase unitAi))
            {
                unitAi.AddComponent<T>().StartEffect(duration,dmg);
                return true;
            }
        }
        return false;
    }
    
}