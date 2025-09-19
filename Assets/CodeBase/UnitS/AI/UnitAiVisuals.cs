using CodeBase.UnitS.AI;
using UnityEngine;
public class UnitAiVisuals : MonoBehaviour
{
    [SerializeField] private FabricCreatingSfxPlayer fabricCreatingSfxPlayer;
    [SerializeField] private UnitSpawnVfxPlayer unitSpawnVfxPlayer;
    [SerializeField] private Animator animator;

    public void PlaySpawnVfx() => unitSpawnVfxPlayer.PlaySpawnVfx();
    public UnitAnimationPlayer unitAnimationPlayer;
    public void PlaySpawnOneShot() => fabricCreatingSfxPlayer.PlayCreateSFX();

    private void Awake()
    {
        unitAnimationPlayer = new UnitAnimationPlayer(animator);
    }
}