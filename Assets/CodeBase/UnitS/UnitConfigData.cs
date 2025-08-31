using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Units/CreateUnitConfig")]
public class UnitConfigData : ScriptableObject
{
    public List<UnitData> UnitDatas;
}

[Serializable]
public class UnitData
{
    public int hp;
    public int armour;
    public int dmg;
    public int updatingCost;
}