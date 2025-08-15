using CodeBase.TweenServices;
using UnityEngine;
using Zenject;

public class UnitFactory : MonoBehaviour
{
    private DiContainer _diContainer;
    private GameObject _miniSkeleton;
    private GameObject _skeleton;
    private GameObject _chest;
    private SpawnTweenService tweenService;
    [Inject]
    public void Construct(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    private void Load()
    {
        _miniSkeleton = Resources.Load<GameObject>("Units/MiniSkeleton");
        _skeleton = Resources.Load<GameObject>("Units/Skeleton");
        _chest = Resources.Load<GameObject>("Units/ChestMonster");
    }

    private void Awake()
    {
        Load();
        tweenService = new SpawnTweenService();
    }

    public void Create(UnitType unitType, Vector3 pos)
    {
        switch (unitType)
        {
            case UnitType.skeleton:
               var skeleton= _diContainer.InstantiatePrefab(_skeleton, pos, Quaternion.identity, null);
                break;
            case UnitType.miniSkeleton:
                var miniskeleton= _diContainer.InstantiatePrefab(_miniSkeleton, pos, Quaternion.identity, null);
                tweenService.SpawnScaleTween(miniskeleton.transform.localScale,miniskeleton,0.2f);
                break;
            case UnitType.chest:
                var chest= _diContainer.InstantiatePrefab(_chest, pos, Quaternion.identity, null);
                tweenService.SpawnScaleTween(chest.transform.localScale,chest,0.2f);
                break;
        }
    }
}