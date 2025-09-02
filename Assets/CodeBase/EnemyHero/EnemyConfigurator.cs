using CodeBase;
using UnityEngine;
using Zenject;
public class EnemyConfigurator : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int armour;
    [SerializeField] private int dmg;
    [SerializeField] private EnemyHeroConfigData config;
    [SerializeField] private Animator animator;
    private LevelSwitcher levelSwitcher;

    [Inject]
    public void Contruct(LevelSwitcher _levelSwitcher)
    {
        levelSwitcher = _levelSwitcher;
    }

    public int GetHpCount() => hp;
    public int GetArmourCount() => armour;
    public int GetDmgCount() => dmg;
    private void ConfigData(EnemyHeroConfigData _config)
    {
        hp = (int)_config.healthPointCurve.Evaluate(levelSwitcher.GetCurrentLvlIndex());
        armour = _config.armour;
        dmg = (int)_config.damageCurve.Evaluate(levelSwitcher.GetCurrentLvlIndex());;
        animator.SetFloat("AttackSpeed", _config.attackSpeed);
        
    }


    private void Awake()
    {
        ConfigData(config);
    }
}
