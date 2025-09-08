using CodeBase;
using DG.Tweening;
using UnityEngine;

public class DeathOfMimic : IUnitDeathBehaviourStrategy
{
    public void Die(UnitHealth unitHealth)
    {
        unitHealth.objectFromUnitInside.gameObject.SetActive(true);
        unitHealth.objectFromUnitInside.gameObject.transform.DOScale(Vector3.one, 0.5f);
    }
}