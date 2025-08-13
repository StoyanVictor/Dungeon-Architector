using System.Collections;
using CodeBase.EnemyHero;
using UnityEngine;

public class PoisonTrap : MultiTargetTrapBase
{
    [SerializeField] private float effectRange;
    private bool canCast;
    public bool EffectUsing()
    {
        var objects = Physics.OverlapSphere(transform.position, effectRange);
        foreach (var obj in objects)
        {
            if (obj.TryGetComponent(out EnemyHeroAiBase unitAi))
            {
                unitAi.gameObject.AddComponent<PoisonEffect>().StartPoison(5,5);
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        if (!canCast) StartCoroutine(PoisonCasting(5));
    }

    private IEnumerator PoisonCasting(int s)
    {
        canCast = true;
        EffectUsing();
        yield return new WaitForSeconds(s);
        canCast = false;
    }
}