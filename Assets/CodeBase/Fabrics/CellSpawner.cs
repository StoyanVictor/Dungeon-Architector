using UnityEngine;
using Zenject;

public class CellSpawner : MonoBehaviour
{
    [SerializeField] private Transform parent;
    private DiContainer _diContainer;
    private GameObject cell;
    
    [Inject]
    public void Construct(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    private void Load()
    {
        cell = Resources.Load<GameObject>("GameServices/Cell");
    }

    private void Awake()
    {
        Load();
    }

    public GameObject Create()
    {
        return _diContainer.InstantiatePrefab(cell,Vector3.zero,Quaternion.identity,parent);
    }
}