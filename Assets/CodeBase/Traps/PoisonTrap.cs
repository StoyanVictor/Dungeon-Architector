using System;
using System.Collections;
using CodeBase.EnemyHero;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PoisonTrap : MultiTargetTrapBase<PoisonEffect>
{
    private bool canCast;

    private void Update()
    {
        if (!canCast) PoisonCasting(5);
    }

    private async UniTask PoisonCasting(int s)
    {
        canCast = true;
        EffectUsing();
        await UniTask.Delay(TimeSpan.FromSeconds(s));
        canCast = false;
    }
}