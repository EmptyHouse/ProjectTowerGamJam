using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHCharacterComponent : EHActorComponent
{
    public EHCharacter OwningCharacter { get; private set; }


    #region override functions

    protected override void InitializeOwningActor()
    {
        base.InitializeOwningActor();
        OwningCharacter = (EHCharacter) OwningActor;
    }

    #endregion override functions
}
