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
    }

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => buildingSpawner.SelectBuilding(buildingData.buildingPrefabId));
        button.onClick.AddListener(() => buildingSpawner.SetsCellsCountToBuild(buildingData.cellsToBuild));

    }
}
