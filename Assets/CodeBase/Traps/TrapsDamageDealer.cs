using UnityEngine;

public class TrapsDamageDealer : MonoBehaviour
{
    [SerializeField] private int dmg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable unitHealth))
        {
            unitHealth.TakeDamage(dmg);
        }
    }
}