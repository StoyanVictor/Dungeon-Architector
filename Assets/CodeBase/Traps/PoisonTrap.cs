using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PoisonTrap : MultiTargetTrapBase<PoisonEffect>
{
    [SerializeField] private UnitConfigurator configurator;
    private bool canCast;
    
    private void Update()
    {
        if (!canCast) PoisonCasting(5);
    }

    private async UniTask PoisonCasting(int s)
    {
        canCast = true;
        EffectUsing(5,configurator.GetDmgCount());
        await UniTask.Delay(TimeSpan.FromSeconds(s));
        canCast = false;
    }
}