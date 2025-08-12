
using UnityEngine;

public class ProjectileDamageDealer : MonoBehaviour
{
    [SerializeField] private int dmg;

    public void SetupDamageCount(int _dmg)
    {
        dmg = _dmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out UnitHealth unitHealth))
        {
            unitHealth.TakeDamage(dmg);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
