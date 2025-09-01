using System;
using System.Collections;
using CodeBase.EnemyHero;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SlowTrap : MultiTargetTrapBase<SlowEffect>
{
    private bool canCast;

    private void Update()
    {
        if (!canCast) SlowCasting(5);
    }

    private async UniTask SlowCasting(int s)
    {
        canCast = true;
        EffectUsing();
        await UniTask.Delay(TimeSpan.FromSeconds(s));
        canCast = false;
    }
}