using CodeBase;
using CodeBase.TweenServices;
using UniRx;
using UnityEngine;
using Zenject;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private FabricCreatingSfxPlayer sfxPlayer;
    private SpawnTweenService tweenService;
    private UnitFactory unitFactory;
    private UnitType unitType;
    private Bank bank;

    [Inject]
    public void Construct(Bank _bank,UnitFactory _unitFactory)
    {
        bank = _bank;
        unitFactory = _unitFactory;

    }
    
    public UnitType GetUnitType() => unitType;

    public void SetUnitType(UnitType _unitType)
    {
        unitType = _unitType;
    }

    private void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).Subscribe(_ => SpawnUnit()).AddTo(this);
    }

    private void SpawnUnit()
    {
        if (bank.SpendMoney(10))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, targetLayer))
            {
                unitFactory.Create(GetUnitType(),hit.point);
                sfxPlayer.PlayCreateSFX();
            }
        }
    }
}