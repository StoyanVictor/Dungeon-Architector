using UnityEngine;

public class EnemyConfigurator : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int armour;
    [SerializeField] private int dmg;
    [SerializeField] private EnemyHeroConfigData config;
    [SerializeField] private Animator animator;

    public int GetHpCount() => hp;
    public int GetArmourCount() => armour;
    public int GetDmgCount() => dmg;
    private void ConfigData(EnemyHeroConfigData _config)
    {
        hp = _config.hp;
        armour = _config.armour;
        dmg = _config.dmg;
        animator.SetFloat("AttackSpeed", _config.attackSpeed);
    }


    private void Awake()
    {
        ConfigData(config);
    }
}
