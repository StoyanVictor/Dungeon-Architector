using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UnitUpgradeButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshPro upgradePriceTxt;
    [SerializeField] private UnitConfigurator configurator;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        button.onClick.AddListener(() => configurator.LvlUp());
        Observable.EveryUpdate().Subscribe(_ => upgradePriceTxt.text = configurator.GetCurrentUpdatePrice()+" $").AddTo(this);
    }
}