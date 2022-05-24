using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHUnitBuildPad : EHActor
{
    public EHTowerUnit OccupyingTower { get; private set; }
    public bool IsOccupied => OccupyingTower != null;
    

    [SerializeField]
    private Transform SpawnTransform;
    [SerializeField]
    private Transform ActiveMesh;
    
    #region monobehaviour methods

    protected override void Awake()
    {
        base.Awake();
        ActiveMesh.gameObject.SetActive(false);
    }
    // In the future may want to move this logic to the player controller to separate player controller logic from build pads
    protected void OnTriggerEnter(Collider PlayerCollider)
    {
        EHPlayerCharacter PlayerCharacter = PlayerCollider.GetComponent<EHPlayerCharacter>();
        if (PlayerCharacter == null) return;
        EHPlayerState PlayerState = PlayerCharacter.OwningPlayerState;
        if (PlayerState == null) return;
        PlayerState.SetBuildPadActive(this);
        ActiveMesh.gameObject.SetActive(true);
    }

    protected void OnTriggerExit(Collider PlayerCollider)
    {
        EHPlayerCharacter PlayerCharacter = PlayerCollider.GetComponent<EHPlayerCharacter>();
        if (PlayerCharacter == null) return;
        EHPlayerState PlayerState = PlayerCharacter.OwningPlayerState;
        if (PlayerState == null) return;
        ActiveMesh.gameObject.SetActive(false);
        
        if (PlayerState.GetActiveBuildPad() == this) 
            PlayerState.SetBuildPadActive(null);
    }
    #endregion monobehaivour methods

    public void ActivateBuildPad()
    {
        ActiveMesh.gameObject.SetActive(true);
    }

    public void DeactivateBuildPad()
    {
        ActiveMesh.gameObject.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="TowerUnit"></param>
    public void BuildTowerUnit(EHTowerUnit TowerUnit)
    {
        OccupyingTower = CreateActor(TowerUnit, SpawnTransform.position, SpawnTransform.rotation);
    }

    public void RemoveTowerUnit()
    {
        if (!OccupyingTower)
            return;
        // In the future we may want to add an effect of some kind when we destroy our tower
        DestroyActor(OccupyingTower);
    }
}
