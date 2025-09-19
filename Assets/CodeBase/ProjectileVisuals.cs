using UnityEngine;

public class ProjectileVisuals : MonoBehaviour
{
    [SerializeField] private ParticleSystem poisonVfx;

    public void PlayPoisonVFX() => poisonVfx.Play();  
    public void PlayCommonVFX()
    {
    }

}