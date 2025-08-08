using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildingSelector : MonoBehaviour
{
    public BuildingData buildingData;
    private Button button;
    private BuildingSpawner buildingSpawner;

    [Inject]
    public void Construct(BuildingSpawner _buildingSpawner)
    {
        buildingSpawner = _buildingSpawner;
        Debug.LogError(buildingSpawner);
    }

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => buildingSpawner.SelectBuilding(buildingData.buildingPrefabId));
    }
}
