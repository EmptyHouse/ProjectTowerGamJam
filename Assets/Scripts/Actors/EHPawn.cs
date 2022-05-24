using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHPawn : EHActor
{
    private EHPlayerController OwningController;

    public void SetPlayerController(EHPlayerController PlayerController)
    {
        this.OwningController = PlayerController;
    }

    public EHPlayerController GetOwningController() => OwningController;
}
