using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wizzardFireBall;
    [SerializeField] private Vector3 offset;
    public void SpawnProjectile()
    {
        GameObject projectile = Instantiate(wizzardFireBall,transform.position + offset ,Quaternion.identity);
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 4f,ForceMode.Impulse);
    }
}