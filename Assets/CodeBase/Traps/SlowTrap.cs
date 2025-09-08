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
        if (!canCast) SlowCasting(5,2);
    }

    private async UniTask SlowCasting(int s,int slowPower)
    {
        canCast = true;
        EffectUsing(s,slowPower);
        await UniTask.Delay(TimeSpan.FromSeconds(s));
        canCast = false;
    }
}