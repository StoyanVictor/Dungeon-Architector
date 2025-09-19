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
            
            if (obj.TryGetComponent(out UnitAiController ai))
            {
                switch (type)
                {
                    case UnitTypes.Chest:
                        ConstructingUnit(ai,new NoMove(),new MimicAttack(),new DeathOfMimic());
                        break;
                    case UnitTypes.Skeleton:
                        ConstructingUnit(ai,new SimpleMove(),new MeleeAttack(),new DeathWithoutEffect());
                        break;
                    case UnitTypes.PoisonTrap:
                        ConstructingUnit(ai,new NoMove(),new NoAttack(),new DeathWithoutEffect());
                        break;
                    case UnitTypes.PurpleSphere:
                        ConstructingUnit(ai,new SimpleMove(),new HellTowerAttack(),new DeathWithoutEffect());
                        break;
                    case UnitTypes.Ogr:
                        ConstructingUnit(ai,new SimpleMove(),new MeleeAttack(),new DeathWithoutEffect());
                        break;
                    case UnitTypes.Cactus:
                        ConstructingUnit(ai,new NoMove(),new AoeAttack(),new DeathWithoutEffect());
                        break;
                    case UnitTypes.MageTower:
                        ConstructingUnit(ai,new NoMove(),new MagicTowerAttack(),new DeathWithoutEffect());
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

        private void ConstructingUnit(UnitAiController ai,IMoveBehaviourStrategy moveBehaviour, IAttackBehaviourStrategy attackBehaviour,
            IUnitDeathBehaviourStrategy deathBehaviour)
        {
            ai.attackStrategy = attackBehaviour;
            ai.moveStrategy = moveBehaviour;
            ai.aiLogic.unitHealth.deathStrategy = deathBehaviour;
        }
    }
}