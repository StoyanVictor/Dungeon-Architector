using UnityEngine;

public class EnemyHeroDamageDealer : MonoBehaviour
{
    [SerializeField] private int dmg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out UnitHealth unitHealth))
        {
            unitHealth.TakeDamage(dmg);
        }
    }
}
