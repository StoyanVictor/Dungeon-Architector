using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildingSelector : MonoBehaviour
{
    public BuildingData buildingData;
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
        button.onClick.AddListener(() => buildingSpawner.SelectBuilding(buildingData.buildingPrefabId));
        button.onClick.AddListener(() => buildingSpawner.SetsCellsCountToBuild(buildingData.cellsToBuild));
        button.onClick.AddListener(() => buttonTween.PressButtonShakeTween(rectTransform));

    }
}
