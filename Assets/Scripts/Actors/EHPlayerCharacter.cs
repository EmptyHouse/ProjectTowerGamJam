using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHPlayerCharacter : EHCharacter
{
    public EHMovementComponent MovementComponent { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        MovementComponent = GetComponent<EHMovementComponent>();
    }
}
