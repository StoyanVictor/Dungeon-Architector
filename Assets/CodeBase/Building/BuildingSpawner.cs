using System;
using CodeBase;
using CodeBase.TweenServices;
using CodeBase.UnitS.AI;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;
public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private int cellsCountToBuild;
    [SerializeField] private FabricCreatingSfxPlayer sfxPlayer;
    private int currentBuildingPrice;
    private GameObject buildingPrefab;
    private SpawnTweenService tweenService;
    private AsyncOperationHandle<GameObject> loadHandle;
    private Bank bank;
    private DiContainer diContainer;
    private UnitFactory factory;
    private UnitTypes unitType;
    
    [Inject]
    public void Construct(Bank _bank,DiContainer _diContainer)
    {
        bank = _bank;
        diContainer = _diContainer;
    }

    private void Start()
    {
        tweenService = new SpawnTweenService();
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).Subscribe(_ => ClearResources()).AddTo(this);
        factory = new UnitFactory();
    }

    public bool IsBuildingPrefabAvailable()
    {
        if (buildingPrefab != null)
            return true;
        else
        {
            return false;
        }
    }

    public int SetBuildingPrice(int price) => currentBuildingPrice = price; 
    public int SetsCellsCountToBuild(int cellsCount) => cellsCountToBuild = cellsCount;

    public int GetCellsCountToBuild() => cellsCountToBuild;
    
    private GameObject ghostInstance;
    
    public void SelectBuilding(string buildingId)
    {
        loadHandle = Addressables.LoadAssetAsync<GameObject>(buildingId);
        loadHandle.Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                buildingPrefab = handle.Result;
                unitType = buildingPrefab.GetComponent<UnitMarker>().type;
                ShowGhostPreview();
            }
            
            else
            {
                Debug.LogError($"❌ Failed to load building: {buildingId}");
            }
        };
    }


    public void DestroyGhostBuilding(bool isEmpty)
    {
        if (isEmpty && ghostInstance != null)
        {
            Destroy(ghostInstance);
        }
        else if (!isEmpty && buildingPrefab != null && ghostInstance == null)
        {
            ghostInstance = Instantiate(buildingPrefab);
            SetGhostMaterialTransparent(ghostInstance);
            return;
        }
    }

    void ShowGhostPreview()
    {
        if (ghostInstance != null)
            Destroy(ghostInstance);
        ghostInstance = Instantiate(buildingPrefab);
        SetGhostMaterialTransparent(ghostInstance);
    }

    public void MoveGhostTo(Vector3 pos,  bool isEmpty)
    {
        if (ghostInstance != null && !isEmpty)
            ghostInstance.transform.position = pos;
    }

    public GameObject PlaceBuilding(Vector3 pos, bool isEmpty)
    {
        if (buildingPrefab == null || isEmpty)
        {
            Debug.Log("❗ Building not loaded yet");
            return null;
        }
        else if (!isEmpty && bank.SpendMoney(currentBuildingPrice))
        {
            var obj = factory.CreateUnit(buildingPrefab, pos, unitType, diContainer);
            UnitSpawnCheck(obj);
            tweenService.SpawnScaleTween(obj.transform.localScale,obj,0.5f);
            Destroy(ghostInstance);
            ghostInstance = null;
            ClearResources();
            return obj;
        }

        return null;
    }

    private void UnitSpawnCheck(GameObject unit)
    {
        if (unit.TryGetComponent(out UnitAi unitAi))
        {
            unitAi.EnableCollider();
            unitAi.StartWorkWithRealUnit();
            unitAi.PlaySpawnOneShot();
            unitAi.PlaySpawnVfx();
        }
        else
        {
            sfxPlayer.PlayCreateSFX();
            unit.GetComponent<TrapVfxPlayer>().ShowVfx();
            return;
        }
    }

    void SetGhostMaterialTransparent(GameObject obj)
    {
        var renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (var rend in renderers)
        {
            foreach (var mat in rend.materials)
            {
                mat.shader = Shader.Find("Universal Render Pipeline/Unlit");
                mat.color = Color.yellow;
            }
        }
        if(obj.TryGetComponent(out TrapVfxPlayer trapVfxPlayer))
            trapVfxPlayer.HideVfx();
        else
            return;
    }

    public void ClearResources()
    {
        if (buildingPrefab != null)
        {
            Addressables.Release(loadHandle);
            buildingPrefab = null;
        }

        if (ghostInstance != null)
        {
            Destroy(ghostInstance);
        }

    }
    
}
