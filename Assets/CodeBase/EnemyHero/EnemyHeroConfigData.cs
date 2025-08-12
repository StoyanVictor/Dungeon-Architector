using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/CreateEnemyConfig")]
public class EnemyHeroConfigData : ScriptableObject
{
    public int hp;
    public int armour;
    public int dmg;
}