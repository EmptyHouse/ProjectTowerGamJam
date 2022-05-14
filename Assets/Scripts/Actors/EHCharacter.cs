using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHCharacter : EHPawn
{
    public EHMovementComponent MovementComponent { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        MovementComponent = GetComponent<EHMovementComponent>();
    }
}
