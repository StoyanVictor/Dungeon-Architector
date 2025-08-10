using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamageDealer : MonoBehaviour
{
    [SerializeField] private int dmg;

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
