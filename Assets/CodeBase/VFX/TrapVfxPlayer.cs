using UnityEngine;

public class TrapVfxPlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;

    public void HideVfx()
    {
        particleSystem.gameObject.SetActive(false);
    }
    public void ShowVfx()
    {
        particleSystem.gameObject.SetActive(true);
    }
    
}