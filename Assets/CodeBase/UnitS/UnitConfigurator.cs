using System;
using CodeBase;
using UnityEngine;
using Zenject;

public class UnitConfigurator : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int armour;
    [SerializeField] private int dmg;
    [SerializeField] private UnitConfigData config;
    [SerializeField] private int currentLvl;
    [SerializeField] private GameObject updateUi;
    [SerializeField] private bool  canShowUpgradeMenu;
    [SerializeField] private Animator  animator;
    
    public Action OnLevelUp;
    private Bank bank;

    [Inject]
    public void Construct(Bank _bank)
    {
        bank = _bank;
    }
    
    public int GetCurrentLvl() => currentLvl;
    private void OnMouseDown()
    {
        ShowUpgradeMenu();
    }

    private void ShowUpgradeMenu()
    {
        if (!canShowUpgradeMenu)
        {
            updateUi.SetActive(true);
            canShowUpgradeMenu = true;
        }
        else
        {
            updateUi.SetActive(false);
            canShowUpgradeMenu = false;
        }

    }

    public int GetHpCount() => hp;

    public void LvlUp()
    {
        print(bank);
        if (bank.SpendMoney(config.UnitDatas[currentLvl].updatingCost))
        {
            currentLvl++;
            ConfigData(config);
            OnLevelUp?.Invoke();
        }
        else
        {
            Debug.Log($"<color=orange>Have no money for update!</color>");
        }
    }
    
    public int GetArmourCount() => armour;
    public int GetDmgCount() => dmg;
    private void ConfigData(UnitConfigData _config)
    {
        hp = _config.UnitDatas[currentLvl].hp;
        armour = _config.UnitDatas[currentLvl].armour;
        dmg = _config.UnitDatas[currentLvl].dmg;
        animator.SetFloat("AttackSpeed", _config.UnitDatas[currentLvl].attackSpeed);
    }


    private void Awake()
    {
        ConfigData(config);
    }
}