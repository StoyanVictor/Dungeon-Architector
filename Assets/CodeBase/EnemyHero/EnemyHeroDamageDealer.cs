using System;
using UnityEngine;

public class EnemyHeroDamageDealer : MonoBehaviour 
{
    [SerializeField] private int dmg;
    [SerializeField] private EnemyConfigurator configurator;
    public void SetupDamageCount(int _dmg)
    {
        dmg = _dmg;
    }

    private void Start()
    {
        SetupDamageCount(configurator.GetDmgCount());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out UnitHealth unitHealth))
        {
            unitHealth.TakeDamage(dmg);
        }
    }
}
