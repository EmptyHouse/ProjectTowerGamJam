using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHBaseConsumable : EHActor
{
    [SerializeField]
    private Transform ItemContainer;
    private Vector3 ItemContainerOffset;
    private AnimationCurve HoverCurve;
    [SerializeField]
    private float HoverHeight = .5f;
    [SerializeField]
    private float HoverFrequency = 1f;
    private float CurrentTimeOffset = 0;
    
    #region monobehaviour methods
    protected override void Awake()
    {
        base.Awake();
        ItemContainerOffset = ItemContainer.localPosition;
    }

    protected virtual void Update()
    {
        CurrentTimeOffset += Time.deltaTime;

        ItemContainer.localPosition = ItemContainerOffset + Vector3.up * Mathf.Sin(CurrentTimeOffset * HoverFrequency) * HoverHeight;
    }
    protected void OnTriggerEnter(Collider other)
    {
        EHPlayerCharacter PlayerCharacter = other.GetComponent<EHPlayerCharacter>();

        if (PlayerCharacter == null) return;
        OnPlayerGrabbedConsumable(PlayerCharacter);
    }
    #endregion monobehaviour methods

    /// <summary>
    /// This function is called when the player enters the collider for the consumable item
    /// </summary>
    protected virtual void OnPlayerGrabbedConsumable(EHPlayerCharacter PlayerCharacter)
    {
        
    }
}
