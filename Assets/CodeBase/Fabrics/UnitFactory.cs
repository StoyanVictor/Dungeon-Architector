using System;
using UnityEngine;
using Zenject;

public class UnitFactory : MonoBehaviour
{
    private DiContainer _diContainer;
    private GameObject _miniSkeleton;
    private GameObject _skeleton;
    
    [Inject]
    public void Construct(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    private void Load()
    {
        _miniSkeleton = Resources.Load<GameObject>("Units/MiniSkeleton");
        _skeleton = Resources.Load<GameObject>("Units/Skeleton");
    }

    private void Awake()
    {
        Load();
    }

    public void Create(UnitType unitType, Vector3 pos)
    {
        switch (unitType)
        {
            case UnitType.skeleton:
                _diContainer.InstantiatePrefab(_skeleton, pos, Quaternion.identity, null);
                break;
            case UnitType.miniSkeleton:
                _diContainer.InstantiatePrefab(_miniSkeleton, pos, Quaternion.identity, null);
                break;
        }
    }
}