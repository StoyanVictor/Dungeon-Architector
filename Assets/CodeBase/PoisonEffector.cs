using Cysharp.Threading.Tasks;

public class PoisonEffector : IEnemyEffector
{
    private bool isAlreadyCasting;
    
    public async void UseEffect(int duration,int effectValue, EnemyHeroHealth heroHealth,EnemyEffectorVisualizer visualizer)
    {
        if (!isAlreadyCasting)
        {
            int time = 0;
            visualizer.PlayPoisonVfx();
            isAlreadyCasting = true;
            while (time < duration)
            {
                heroHealth.TakeDamage(effectValue);
                await UniTask.WaitForSeconds(1);
                time++;
            }
            isAlreadyCasting = false;
            visualizer.StopPoisonVfx();
        }
    }
}