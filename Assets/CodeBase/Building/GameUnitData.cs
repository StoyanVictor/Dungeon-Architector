using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Units", menuName = "Units/CreateNewUnit")]
public class GameUnitData : ScriptableObject
{
    public string unitPrefabId;
    public int cellsToPlace;

}
