using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EHMovementComponent : EHCharacterComponent
{
    public enum EMovementState
    {
        Walk,
        Run,
    }

    private float WalkSpeed = 3f;
    private float RunSpeed = 7f;

    private CharacterController MovementComponent;
    private Vector2 Velocity;
    private Vector2 CurrentInput;

    #region monobehaviour functions

    protected override void Awake()
    {
        base.Awake();
        MovementComponent = GetComponent<CharacterController>();
    }

    protected void Update()
    {
        UpdateMovementSpeed();
    }
    #endregion monobehaviour functions

    public void SetMovementInput(Vector2 MovementInput)
    {
        CurrentInput = MovementInput;
    }

    public void SetLookingInput(Vector2 DirectionalInput)
    {
        float Rotation = Mathf.Rad2Deg * Mathf.Atan2(DirectionalInput.x, DirectionalInput.y);
    }

    private void UpdateMovementSpeed()
    {
        
        Velocity = new Vector3(CurrentInput.x, 0, CurrentInput.y).normalized * WalkSpeed;
        MovementComponent.Move(Velocity * Time.deltaTime);
    }
}