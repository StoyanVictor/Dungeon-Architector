using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class BuildingSelector : MonoBehaviour
{
    public GameUnitData gameUnitData;
    private Button button;
    private BuildingSpawner buildingSpawner;
    private RectTransform rectTransform;
    private ButtonTweenService buttonTween;

    [Inject]
    public void Construct(BuildingSpawner _buildingSpawner)
    {
        buildingSpawner = _buildingSpawner;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        buttonTween = new ButtonTweenService();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => SelectButtonLogic());
    }

    private void SelectButtonLogic()
    {
        buttonTween.PressButtonShakeTween(rectTransform);
        buildingSpawner.SetsCellsCountToBuild(gameUnitData.cellsToPlace);
        buildingSpawner.SelectBuilding(gameUnitData.unitPrefabId);
        buildingSpawner.SetBuildingPrice(gameUnitData.priceForSpawn);
    }
}
