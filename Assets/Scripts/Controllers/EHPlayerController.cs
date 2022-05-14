using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public enum EButtonEvent
{
    ButtonDown,
    ButtonUp,
}

public class EHPlayerController : EHActor
{
    private const string MoveXAxis = "MoveX";
    private const string MoveYAxis = "MoveY";

    private const KeyCode ShootButton = KeyCode.Mouse0;
    private const KeyCode PlaceTowerButton = KeyCode.Mouse1;
    private const KeyCode TowerSelect1Button = KeyCode.Alpha1;
    private const KeyCode TowerSelect2Button = KeyCode.Alpha2;
    private const KeyCode TowerSelect3Button = KeyCode.Alpha3;

        [Serializable]
    private class EHButtonConfig
    {
        public string ButtonName;
        public KeyCode ButtonKey;
        public UnityEvent ButtonUpEvent;
        public UnityEvent ButtonDownEvent;
        public bool CachedValue;
    }
    
    [Serializable]
    private class EHAxisConfig
    {
        public string AxisName;
        public UnityEvent<float> AxisEvent;
        public float CachedValue;
    }

    // [SerializeField] private List<EHButtonConfig> ButtonConfigs = new List<EHButtonConfig>();
    //
    // [SerializeField] private List<EHAxisConfig> AxisConfigs = new List<EHAxisConfig>();
    [SerializeField] private EHPlayerState AssociatedPlayerState;
    private EHGameCamera GameCamera;
    
    protected override void Awake()
    {
        base.Awake();
    }

    protected void Start()
    {
        GameCamera = Camera.main.GetComponentInParent<EHGameCamera>();
    }

    private void Update()
    {
        Vector2 RawMovementInput = new Vector2(Input.GetAxisRaw(MoveXAxis), Input.GetAxisRaw(MoveYAxis));
        Vector2 AdjustedMovement = GetAdjustedMovementAxis(RawMovementInput);
        Vector2 AdjustedLookDirection = GetLookDirectionFromScreenPoint(Input.mousePosition);

        EHPlayerCharacter PlayerCharacter = AssociatedPlayerState.GetAssociatedPlayerCharacter();
        PlayerCharacter.MovementComponent.SetMovementInput(AdjustedMovement);
    }
    
    // public void BindEventToButton(string ButtonName, UnityAction EventToBind, EButtonEvent ButtonEventType)
    // {
    //     EHButtonConfig SelectedButton = null;
    //     foreach (EHButtonConfig Button in ButtonConfigs)
    //     {
    //         if (Button.ButtonName == ButtonName)
    //         {
    //             SelectedButton = Button;
    //             break;
    //         }
    //     }
    //
    //     if (SelectedButton == null)
    //     {
    //         Debug.LogWarning("Invalid Button Name: " + ButtonName);
    //         return;
    //     }
    //     
    //     switch (ButtonEventType)
    //     {
    //         case EButtonEvent.ButtonDown:
    //             SelectedButton.ButtonDownEvent.AddListener(EventToBind);
    //             return;
    //         case EButtonEvent.ButtonUp:
    //             SelectedButton.ButtonUpEvent.AddListener(EventToBind);
    //             return;
    //     }
    // }
    //
    // public void BindEventToAxis(string AxisName, UnityAction<float> EventToBind)
    // {
    //     EHAxisConfig SelectedAxis = null;
    //     foreach (EHAxisConfig Axis in AxisConfigs)
    //     {
    //         if (Axis.AxisName == AxisName)
    //         {
    //             SelectedAxis = Axis;
    //             break;
    //         }
    //     }
    //     SelectedAxis.AxisEvent.AddListener(EventToBind);
    // }
    //
    // private void UpdateButtonEvents()
    // {
    //     foreach (EHButtonConfig ButtonConfig in ButtonConfigs)
    //     {
    //         bool CurrentButtonValue = Input.GetKey(ButtonConfig.ButtonKey);
    //         if (CurrentButtonValue != ButtonConfig.CachedValue)
    //         {
    //             ButtonConfig.CachedValue = CurrentButtonValue;
    //             if (CurrentButtonValue)
    //             {
    //                 ButtonConfig.ButtonDownEvent?.Invoke();
    //             }
    //             else
    //             {
    //                 ButtonConfig.ButtonUpEvent?.Invoke();
    //             }
    //         }
    //     }
    // }

    private Vector2 GetAdjustedMovementAxis(Vector2 InputDirection)
    {
        Vector3 AdjustedInput =
            GameCamera.transform.TransformDirection(new Vector3(InputDirection.x, 0, InputDirection.y));
        Vector2 MovementAxis = new Vector2(AdjustedInput.x, AdjustedInput.z);
        return MovementAxis;
    }
    
    private Vector2 GetLookDirectionFromScreenPoint(Vector3 MousePosition)
    {
        EHPlayerCharacter PlayerCharacter = AssociatedPlayerState.GetAssociatedPlayerCharacter();
        if (PlayerCharacter == null)
        {
            return Vector2.zero;
        }
        
        Ray CameraRay = GameCamera.CameraComponent.ScreenPointToRay(MousePosition);
        Vector3 CameraHitPosition = CameraRay.origin + CameraRay.direction * (CameraRay.origin.y / -CameraRay.direction.y);
        Vector3 DirectionFromPlayer = CameraHitPosition - PlayerCharacter.GetActorLocation();
        return new Vector2(DirectionFromPlayer.x, DirectionFromPlayer.z);
    }


    private void UpdateMovementDirection(Vector2 MovementInput)
    {
        
    }
    
    public void UpdateLookDirection(Vector2 LookDirection)
    {
        
    }
    
    public void OnFireButtonPressed()
    {
        
    }
    
    public void OnPlaceTowerPressed()
    {
        
    }

    public void OnSelectItem1()
    {
        
    }

    public void OnSelectItem2()
    {
        
    }

    public void OnSelectItem3()
    {
        
    }
}
