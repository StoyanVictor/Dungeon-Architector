using CodeBase.UnitS.AI;
using UnityEngine;
using Zenject;
namespace CodeBase
{
    public class UnitFactory
    {
        public GameObject CreateUnit(GameObject unitObject, Vector3 position, UnitTypes type, DiContainer diContainer)
        {
            var obj = diContainer.InstantiatePrefab(unitObject, position,Quaternion.identity,null);
            
            if (obj.TryGetComponent(out UnitAi ai))
            {
                switch (type)
                {
                    case UnitTypes.Chest:
                        ai.attackStrategy = new MimicAttack();
                        ai.moveStrategy = new NoMove();
                        ai.unitHealth.deathStrategy = new DeathOfMimic();
                        break;
                    case UnitTypes.Skeleton:
                        ai.attackStrategy = new MeleeAttack();
                        ai.moveStrategy = new SimpleMove();
                        ai.unitHealth.deathStrategy = new DeathWithoutEffect();
                        break;
                    case UnitTypes.PoisonTrap:
                        ai.attackStrategy = new NoAttack();
                        ai.moveStrategy = new NoMove();
                        ai.unitHealth.deathStrategy = new DeathWithoutEffect();
                        break;
                    case UnitTypes.PurpleSphere:
                        ai.attackStrategy = new HellTowerAttack();
                        ai.moveStrategy = new SimpleMove();
                        ai.unitHealth.deathStrategy = new DeathWithoutEffect();
                        break;
                    case UnitTypes.Ogr:
                        ai.attackStrategy = new MeleeAttack();
                        ai.moveStrategy = new SimpleMove();
                        ai.unitHealth.deathStrategy = new DeathWithoutEffect();
                        break;
                    case UnitTypes.Cactus:
                        ai.attackStrategy = new AoeAttack();
                        ai.moveStrategy = new NoMove();
                        ai.unitHealth.deathStrategy = new DeathWithoutEffect();
                        break;
                }
            }
            else
            {
                var healthcomponent = obj.GetComponent<UnitHealth>();
                healthcomponent.deathStrategy = new DeathWithoutEffect();
            }
            return obj;
        }
    }
}