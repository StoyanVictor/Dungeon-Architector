using UnityEngine;
public class EnemyEffectorVisualizer : MonoBehaviour
{
    [SerializeField] private ParticleSystem poisonVFX;
    public void PlayPoisonVfx()
    {
        poisonVFX.gameObject.SetActive(true);
        poisonVFX.Play();
    }
    public void StopPoisonVfx() => poisonVFX.gameObject.SetActive(false);

}