using UnityEngine;

public class TrapVfxPlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    
    public void HideVfx()
    {
        particleSystem.Stop();
    }
    public void ShowVfx()
    {
        particleSystem.Play();
    }
}