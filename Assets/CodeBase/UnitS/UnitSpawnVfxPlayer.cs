using System;
using UnityEngine;

public class UnitSpawnVfxPlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem spawnParticle;
    [SerializeField] private GameObject light;

    private void Awake()
    {
        light.SetActive(false);
    }

    public void PlaySpawnVfx()
    {
        light.SetActive(true);
        spawnParticle.Play();
    }
}
