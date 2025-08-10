using UnityEngine;

namespace CodeBase.EnemyHero
{
    public class EnemyHeroChaseState : IEnemyHeroState
    {
        private EnemyHeroAiBase enemyAi;
        
        public EnemyHeroChaseState(EnemyHeroAiBase _enemyAi)
        {
            enemyAi = _enemyAi;
        }

        public void EnterState()
        {
            Debug.LogWarning("Im starting chasing!");
        }

        public void Excute()
        {
            if (enemyAi.CheckForAttackRange())
            {
                enemyAi.SwitchState(new EnemyHeroAttackState(enemyAi));
            }
            enemyAi.Move();
        }

        public void ExitState()
        {
            
        }
    }
}