using System.Collections.Generic;
using CodeBase.EnemyHero;
using UnityEngine;


[CreateAssetMenu(fileName = "Wave", menuName = "Wave/CreateWave")]
public class WaveData : ScriptableObject
{
    [SerializeField] private List<EnemyHeroData> enemies = new List<EnemyHeroData>();
    
    public List<EnemyHeroData> GetAllEnemies() => enemies;
}
