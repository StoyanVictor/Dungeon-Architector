using System;
using UnityEngine;

public class UnitDamageDealer : MonoBehaviour
{
    [SerializeField] private int dmg;
    [SerializeField] private UnitConfigurator configurator;

    private void Start()
    {
        SetupDmgCount(configurator);
    }

    private void SetupDmgCount(UnitConfigurator _configurator) => dmg = _configurator.GetDmgCount();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyHeroHealth enemyHealth))
        {
            enemyHealth.TakeDamage(dmg);
        }
    }
}