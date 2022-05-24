using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHPlayerCharacter : EHCharacter
{
    public EHPlayerState OwningPlayerState { get; private set; }

    public void PossessPlayerCharacter(EHPlayerState PlayerState)
    {
        OwningPlayerState = PlayerState;
    }
}
