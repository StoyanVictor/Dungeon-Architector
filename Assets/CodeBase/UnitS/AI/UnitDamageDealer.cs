using UnityEngine;

public class UnitDamageDealer : MonoBehaviour
{
    [SerializeField] private int dmg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyHeroHealth enemyHealth))
        {
            enemyHealth.TakeDamage(dmg);
        }
    }
}