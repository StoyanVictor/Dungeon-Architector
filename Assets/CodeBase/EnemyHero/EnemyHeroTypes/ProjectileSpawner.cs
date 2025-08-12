using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wizzardFireBall;
    [SerializeField] private Vector3 offset;
    [SerializeField] private EnemyConfigurator configurator;
    public void SpawnProjectile()
    {
        GameObject projectile = Instantiate(wizzardFireBall,transform.position + offset ,Quaternion.identity);
        projectile.GetComponent<ProjectileDamageDealer>().SetupDamageCount(configurator.GetDmgCount());
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 4f,ForceMode.Impulse);
    }
}