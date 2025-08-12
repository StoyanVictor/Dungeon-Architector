using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Units/CreateUnitConfig")]
public class UnitConfigData : ScriptableObject
{
    public int hp;
    public int armour;
    public int dmg;
}