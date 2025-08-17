using System;
using UnityEngine;

public class FabricCreatingSfxPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip createSfx;
    [SerializeField] private AudioSource audioSource;

    public void PlayCreateSFX()
    {
        audioSource.PlayOneShot(createSfx);
    }

    
}
