using System.Collections;
using CodeBase.EnemyHero;
using UnityEngine;

public class SlowTrap : MultiTargetTrapBase<SlowEffect>
{
    private bool canCast;

    private void Update()
    {
        if (!canCast) StartCoroutine(SlowCasting(5));
    }

    private IEnumerator SlowCasting(int s)
    {
        canCast = true;
        EffectUsing();
        yield return new WaitForSeconds(s);
        canCast = false;
    }
}