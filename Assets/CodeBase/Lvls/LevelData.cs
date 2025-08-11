using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level/CreateLvl")]
public class LevelData : ScriptableObject
{
    public List<WaveData> LevelWaves;

}
