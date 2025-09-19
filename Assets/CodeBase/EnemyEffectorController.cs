using UnityEngine;

public class EnemyEffectorController : MonoBehaviour
{
    public IEnemyEffector effector;
    
    public EnemyEffectorVisualizer visualizer;

    private EnemyHeroHealth heroHealth;

    private void Start()
    {
        heroHealth = GetComponent<EnemyHeroHealth>();
        visualizer.StopPoisonVfx();
    }
    public void ApplyEffect( EffectType effectType)
    {
        switch (effectType)
        {
            case EffectType.Common:
                break;
            case EffectType.Poison:
                effector = new PoisonEffector();
                effector.UseEffect(5,5,heroHealth,visualizer);
                break;
            case EffectType.Fear:
                effector = new PoisonEffector();
                effector.UseEffect(5,5,heroHealth,visualizer);
                break;
            
        }
    }
}