using System;
using System.Collections.Generic;
using UnityEngine;
public class ProjectilePool : MonoBehaviour
{
    [Header("Pool")] [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private int poolSize = 1000;
    [SerializeField] private Transform initialPos;

    private Queue<Projectile> pool = new Queue<Projectile>();

    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Projectile p = Instantiate(projectilePrefab, transform);
            p.pool = this;
            p.gameObject.SetActive(false);
            pool.Enqueue(p);
        }
    }

    private void Start()
    {
        CreatePool();
    }

    public Projectile GetProjectile()
    {
        if (pool.Count == 0)
        {
            Projectile cNew = Instantiate(projectilePrefab, transform);
            cNew.gameObject.SetActive(false);
            pool.Enqueue(cNew);
        }

        Projectile projectile = pool.Dequeue();
        projectile.transform.position = initialPos.position;
        projectile.gameObject.SetActive(true);
        return projectile;
    }

    public void ReturnProjectile(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        projectile.transform.SetParent(transform);
        pool.Enqueue(projectile);
    }

    public int GetPoolCount => poolSize;
}

public enum EffectType
{
    Common,
    Poison,
    Fear
}

