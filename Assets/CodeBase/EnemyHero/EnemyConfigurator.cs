using UnityEngine;

public class EnemyConfigurator : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int armour;
    [SerializeField] private int dmg;
    [SerializeField] private EnemyHeroConfigData config;

    public int GetHpCount() => hp;
    public int GetArmourCount() => armour;
    public int GetDmgCount() => dmg;
    private void ConfigData(EnemyHeroConfigData _config)
    {
        hp = config.hp;
        armour = config.armour;
        dmg = config.dmg;
    }


    private void Awake()
    {
        ConfigData(config);
    }
}
