namespace CodeBase.EnemyHero
{
    public interface IEnemyHeroState
    {
        public void EnterState();
        public void Excute();
        public void ExitState();
    }
}