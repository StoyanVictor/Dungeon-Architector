using UnityEngine;

[RequireComponent(typeof(ProjectileLogic))]
[RequireComponent(typeof(ProjectileVisuals))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private EffectType effectType;
    [SerializeField] private ProjectileLogic projectileLogic;
    [SerializeField] private ProjectileVisuals projectileVisuals;

    public ProjectilePool pool;

    private void OnEnable()
    {
        projectileLogic.SelectProjectile(effectType,projectileVisuals);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyHeroHealth heroHealth))
        {
            heroHealth.TakeDamage(projectileLogic.GetDmg());
            other.GetComponent<EnemyEffectorController>().ApplyEffect(effectType);
            pool.ReturnProjectile(this);
        }
        else
        {
            print("HSDOKFSKF");
            pool.ReturnProjectile(this);
        }
    }
}