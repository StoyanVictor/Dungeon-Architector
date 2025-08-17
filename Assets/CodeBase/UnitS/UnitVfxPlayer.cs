using UnityEngine;

public class UnitVfxPlayer : MonoBehaviour
{
   [SerializeField] private ParticleSystem attackParticleSystem;

   public void PlayAttackVfx()
   {
      attackParticleSystem.Play();
   }
}
