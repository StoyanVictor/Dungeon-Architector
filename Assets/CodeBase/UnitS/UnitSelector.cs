using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UnitSelector : MonoBehaviour
{
    private Button button;
    private UnitSpawner unitSpawner;
    public UnitType unitType;

    [Inject]
    public void Contruct(UnitSpawner _unitSpawner)
    {
        unitSpawner = _unitSpawner;
    }

    private void Awake()
    {
        button = GetComponent<Button>();
        Debug.LogError(button);
        button.onClick.AddListener(() => unitSpawner.SetUnitType(unitType));
    }
}