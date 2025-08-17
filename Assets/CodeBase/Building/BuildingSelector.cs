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
        button.onClick.AddListener(() => buildingSpawner.SelectBuilding(gameUnitData.unitPrefabId));
        button.onClick.AddListener(() => buildingSpawner.SetsCellsCountToBuild(gameUnitData.cellsToPlace));
        button.onClick.AddListener(() => buttonTween.PressButtonShakeTween(rectTransform));

    }
}
