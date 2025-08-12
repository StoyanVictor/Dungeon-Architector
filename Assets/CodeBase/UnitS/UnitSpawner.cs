using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase;
using UnityEngine;
using Zenject;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private FabricCreatingSfxPlayer sfxPlayer;
    private UnitFactory unitFactory;
    private UnitType unitType;
    private Bank bank;

    [Inject]
    public void Construct(Bank _bank)
    {
        bank = _bank;
    }

    public UnitType GetUnitType() => unitType;

    public void SetUnitType(UnitType unitType)
    {
        this.unitType = unitType;
    }

    [Inject]
    public void Construct(UnitFactory _unitFactory)
    {
        unitFactory = _unitFactory;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(1) && bank.SpendMoney(10))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, targetLayer))
            {
                Debug.LogWarning(unitType);
               unitFactory.Create(GetUnitType(),hit.point);
               sfxPlayer.PlayCreateSFX();
            }
        }
    }
}