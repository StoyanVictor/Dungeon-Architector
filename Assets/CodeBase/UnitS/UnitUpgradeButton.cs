using UnityEngine;
using UnityEngine.UI;

public class UnitUpgradeButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private UnitConfigurator configurator;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        button.onClick.AddListener(() => configurator.LvlUp());
    }
}