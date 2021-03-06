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
    
    private readonly int AnimHorizontalInput = Animator.StringToHash("HorizontalInput");
    private readonly int AnimVerticalInput = Animator.StringToHash("VerticalInput");

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
        GameCamera = Camera.main.GetComponentInParent<EHGameCamera>();
    }

    protected void Start()
    {
    }

    private void Update()
    {
        EHPlayerCharacter PlayerCharacter = AssociatedPlayerState.GetAssociatedPlayerCharacter();
        Vector2 RawMovementInput = new Vector2(Input.GetAxisRaw(MoveXAxis), Input.GetAxisRaw(MoveYAxis));
        PlayerCharacter.Anim.SetFloat(AnimHorizontalInput, RawMovementInput.x);
        PlayerCharacter.Anim.SetFloat(AnimVerticalInput, RawMovementInput.y);
        Vector2 AdjustedMovement = GetAdjustedMovementAxis(RawMovementInput);
        Vector2 AdjustedLookDirection = GetLookDirectionFromScreenPoint(Input.mousePosition);

        PlayerCharacter.MovementComponent.SetMovementInput(AdjustedMovement);
        PlayerCharacter.MovementComponent.SetLookingInput(AdjustedMovement);
        if (Input.GetKeyDown(PlaceTowerButton))
        {
            OnPlaceTowerPressed();
        }

        if (Input.GetKeyDown(TowerSelect1Button)) OnSelectItem1();
        if (Input.GetKeyDown(TowerSelect2Button)) OnSelectItem2();
        if (Input.GetKeyDown(TowerSelect3Button)) OnSelectItem3();
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

    public void UpdateLookDirection(Vector2 LookDirection)
    {
        
    }
    
    public void OnFireButtonPressed()
    {
        
    }
    
    public void OnPlaceTowerPressed()
    {
        EHTowerUnit NewTowerPrefab = AssociatedPlayerState.GetCurrentlySelectedTower();
        EHUnitBuildPad BuildPad = AssociatedPlayerState.GetActiveBuildPad();
        if (BuildPad != null)
        {
            BuildPad.BuildTowerUnit(NewTowerPrefab);
        }
    }

    public void OnSelectItem1()
    {
        AssociatedPlayerState.SetSelectedTowerIndex(0);
    }

    public void OnSelectItem2()
    {
        AssociatedPlayerState.SetSelectedTowerIndex(1);
    }

    public void OnSelectItem3()
    {
        AssociatedPlayerState.SetSelectedTowerIndex(2);
    }

    public EHPlayerState GetOwningPlayerState() => AssociatedPlayerState;

}
