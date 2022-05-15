using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHMinion : EHCharacter
{
    protected void Update()
    {
        Vector3 ForwardVec = transform.forward;
        MovementComponent.SetMovementInput(new Vector2(ForwardVec.z, -ForwardVec.x));
    }
}
