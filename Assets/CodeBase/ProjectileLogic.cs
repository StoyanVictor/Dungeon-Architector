using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    [SerializeField] private int dmgCount;
    public int GetDmg() => dmgCount;
    public void SelectProjectile(EffectType effectType, ProjectileVisuals visuals)
    {
        switch (effectType)
        {
            case EffectType.Common:
                visuals.PlayCommonVFX();
                break;
            case EffectType.Poison:
                visuals.PlayPoisonVFX();
                break;
        }
    }
}