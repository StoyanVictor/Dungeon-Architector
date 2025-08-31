using System.Collections;
using CodeBase.EnemyHero;
using UnityEngine;

public class PoisonTrap : MultiTargetTrapBase<PoisonEffect>
{
    private bool canCast;

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