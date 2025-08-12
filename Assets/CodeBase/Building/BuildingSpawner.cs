using CodeBase;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private int cellsCountToBuild;
    [SerializeField] private FabricCreatingSfxPlayer sfxPlayer;
    
    private GameObject buildingPrefab;
    
    private AsyncOperationHandle<GameObject> loadHandle;

    private Bank bank;

    [Inject]
    public void Construct(Bank _bank)
    {
        bank = _bank;
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

    public void PlaceBuilding(Vector3 pos, bool isEmpty)
    {
        if (buildingPrefab == null || isEmpty)
        {
            Debug.Log("❗ Building not loaded yet");
            return;
        }
        else if (!isEmpty && bank.SpendMoney(20))
        {
            var obj = Instantiate(buildingPrefab, pos, Quaternion.identity);
            Destroy(ghostInstance);
            sfxPlayer.PlayCreateSFX();
            obj.GetComponent<TrapVfxPlayer>().ShowVfx();
            ghostInstance = null;
            ClearResources();
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
        obj.GetComponent<TrapVfxPlayer>().HideVfx();
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
