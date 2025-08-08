using UnityEngine;

[CreateAssetMenu(fileName = "Bulding", menuName = "Buildings/CreateBuilding")]
public class BuildingData : ScriptableObject
{
    public string buildingPrefabId;
    public int cellsToBuild;

}
