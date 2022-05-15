using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHCompanion : EHActor
{
    public float Speed = 5;
    public float OffsetRadius;

    private EHPlayerCharacter CachedCharacter;
    private Vector3 TargetOffset = new Vector3(-1, 0, -1).normalized;

    protected void Start()
    {
        CachedCharacter = EHGameInstance.Instance.PlayerCharacter;
    }

    protected void Update()
    {
        Vector3 CharacterVelocity = CachedCharacter.MovementComponent.Velocity;
        if (CharacterVelocity.sqrMagnitude > .1)
        {
            TargetOffset = (-CharacterVelocity).normalized;
        }

        Vector3 TargetPosition = CachedCharacter.GetActorLocation();
        Vector3 GoalPosition = (TargetOffset * OffsetRadius) + Vector3.up * transform.position.y + new Vector3(TargetPosition.x, 0, TargetPosition.z);
        SetActorLocation(Vector3.Lerp(GetActorLocation(), GoalPosition, Time.deltaTime * Speed));
    }
}
