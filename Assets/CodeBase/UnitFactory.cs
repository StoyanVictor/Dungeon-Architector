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
            var ai = obj.GetComponent<UnitAi>();

            switch (type)
            {
                case UnitTypes.Chest:
                    ai.attackStrategy = new NoAttack();
                    ai.moveStrategy = new NoMove();
                    break;
                case UnitTypes.Skeleton:
                    ai.attackStrategy = new MeleeAttack();
                    ai.moveStrategy = new SimpleMove();
                    break;
                case UnitTypes.Ogr:
                    ai.attackStrategy = new MeleeAttack();
                    ai.moveStrategy = new SimpleMove();
                    break;
                case UnitTypes.Cactus:
                    ai.attackStrategy = new AoeAttack();
                    ai.moveStrategy = new NoMove();
                    break;
            }
            return obj;
        }
    }
}