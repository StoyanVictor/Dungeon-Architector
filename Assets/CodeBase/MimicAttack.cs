using CodeBase;
using CodeBase.UnitS.AI;
using DG.Tweening;
using UnityEngine;

public class MimicAttack : IAttackBehaviourStrategy
{
    private bool canCast;
    public void Attack(UnitAi ai)
    {
        ai.unitAnimationPlayer.PlayAttackAnimation();
        if (ai.CheckForAttackRange() && !canCast)
        {
            ai.unitAnimationPlayer.PlayIdleAnimation();
            Collider[] enemies;
            enemies = Physics.OverlapSphere(ai.gameObject.transform.position, 5);
            foreach (var enemy in enemies)
            {
                if (enemy.TryGetComponent(out EnemyHeroHealth enemyHealth) && !canCast)
                {
                    GameObject obj = enemyHealth.gameObject;
                    canCast = true;
                   var a = obj.transform.DOScale(Vector3.zero, 0.1f);
                   a.onComplete = () => HideObject(ai, obj);
                   DOTween.Complete(a);
                }
            }
        }
    }

    private void HideObject(UnitAi ai, GameObject obj)
    {
        obj.SetActive(false);
        ai.unitHealth.objectFromUnitInside = obj;
        ai.attackStrategy = new NoAttack();
    }
}