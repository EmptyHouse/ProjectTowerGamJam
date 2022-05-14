using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EHPlayerState : MonoBehaviour
{
    #region player events
    [SerializeField]
    private EHPlayerCharacter PossessedCharacter;

    private int CurrentSelectedTowerIndex;
    [SerializeField]
    private List<EHTowerUnit> AvailableTowerUnits = new List<EHTowerUnit>();
    #endregion player events
    
    public int Credits { get; private set; }

    public void AdjustCredits(int CreditAdjustment)
    {
        Credits += CreditAdjustment;
        if (Credits < 0)
        {
            Credits = 0;
        }
    }

    public EHPlayerCharacter GetAssociatedPlayerCharacter()
    {
        return PossessedCharacter;
    }
    
    #region tower functionality
    public EHTowerUnit GetCurrentlySelectedTower()
    {
        return AvailableTowerUnits[CurrentSelectedTowerIndex];
    }

    public void SetSelectedTowerIndex(int Index)
    {
        if (Index < 0) Index = 0;
        else if (Index >= AvailableTowerUnits.Count) Index = AvailableTowerUnits.Count - 1;
        
        CurrentSelectedTowerIndex = Index;
    }

    public int GetSelectedTowerIndex() => CurrentSelectedTowerIndex;
    
    #endregion tower functionality
}
