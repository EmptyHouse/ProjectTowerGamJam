using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EHPlayerState : MonoBehaviour
{
    #region player events
    [SerializeField]
    private EHPlayerCharacter PossessedCharacter;
    #endregion player events
    
    public int Credits { get; private set; }

    public void AdjustCredits(int CreditAdjustement)
    {
        Credits += CreditAdjustement;
        if (Credits < 0)
        {
            Credits = 0;
        }
    }

    public EHPlayerCharacter GetAssociatedPlayerCharacter()
    {
        return PossessedCharacter;
    }
}
