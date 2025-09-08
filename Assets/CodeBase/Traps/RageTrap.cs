using System;
using Cysharp.Threading.Tasks;
public class RageTrap : MultiTargetTrapBase<RageEffect>
{
    private bool canCast;

    private void Update()
    {
        if (!canCast) RageCasting(5,2);
    }
    private async UniTask RageCasting(int s,int attackSpeed)
    {
        canCast = true;
        EffectUsing(s,attackSpeed);
        await UniTask.Delay(TimeSpan.FromSeconds(s));
        canCast = false;
    }
}