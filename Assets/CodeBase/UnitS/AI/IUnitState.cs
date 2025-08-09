namespace CodeBase.UnitS.AI
{
    public interface IUnitState
    {
        public void EnterState();
        public void Excute();
        public void ExitState();
    }
}