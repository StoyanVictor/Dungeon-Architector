using UnityEngine;

public class UnitSfxPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip moveSFX;
    [SerializeField] private AudioClip attackSFX;
    public AudioSource audioSource;

    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(moveSFX);
    }
    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSFX);
    }
}