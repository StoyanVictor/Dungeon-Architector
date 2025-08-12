using UnityEngine;

public class UnitConfigurator : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int armour;
    [SerializeField] private int dmg;
    [SerializeField] private UnitConfigData config;

    public int GetHpCount() => hp;
    public int GetArmourCount() => armour;
    public int GetDmgCount() => dmg;
    private void ConfigData(UnitConfigData _config)
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