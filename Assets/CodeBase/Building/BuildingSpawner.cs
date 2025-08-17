using System;
using CodeBase;
using CodeBase.TweenServices;
using CodeBase.UnitS.AI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;
public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private int cellsCountToBuild;
    [SerializeField] private FabricCreatingSfxPlayer sfxPlayer;
    
    private GameObject buildingPrefab;
    private SpawnTweenService tweenService;
    private AsyncOperationHandle<GameObject> loadHandle;
    private Bank bank;

    [Inject]
    public void Construct(Bank _bank)
    {
        bank = _bank;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))ClearResources();
    }

    private void Start()
    {
        tweenService = new SpawnTweenService();
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

    public int SetsCellsCountToBuild(int cellsCount) => cellsCountToBuild = cellsCount;

    public int GetCellsCountToBuild() => cellsCountToBuild;
    
    private GameObject ghostInstance;
    
    public void SelectBuilding(string buildingId)
    {
        Debug.LogError("Hellow");
        loadHandle = Addressables.LoadAssetAsync<GameObject>(buildingId);
        loadHandle.Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                buildingPrefab = handle.Result;
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
            Debug.LogError(buildingPrefab);
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
        Debug.LogError($"Im trying to build broo!!!");

        if (buildingPrefab == null || isEmpty)
        {
            Debug.Log("❗ Building not loaded yet");
            return null;
        }
        else if (!isEmpty && bank.SpendMoney(20))
        {
            var obj = Instantiate(buildingPrefab, pos, Quaternion.identity);
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
            Destroy(ghostInstance);
    }
    
}
