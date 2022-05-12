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
    
    
    [Serializable]
    private class FButtonConfig
    {
        public string ButtonName;
        public KeyCode ButtonKey;
        public UnityAction ButtonUpEvent;
        public UnityAction ButtonDownEvent;
        public bool CachedValue;
    }
    
    [Serializable]
    private class FAxisConfig
    {
        public string AxisName;
        public UnityAction<float> AxisEvent;
        public float CachedValue;
    }

    [SerializeField] private List<FButtonConfig> ButtonConfigs = new List<FButtonConfig>();

    [SerializeField] private List<FAxisConfig> AxisConfigs = new List<FAxisConfig>();
    
    
    

    protected override void Awake()
    {
        base.Awake();
        
    }
    private void Update()
    {
    }
    
    public void BindEventToButton(string ButtonName, UnityAction EventToBind, EButtonEvent ButtonEventType)
    {
        FButtonConfig SelectedButton = null;
        foreach (FButtonConfig Button in ButtonConfigs)
        {
            if (Button.ButtonName == ButtonName)
            {
                SelectedButton = Button;
                break;
            }
        }

        if (SelectedButton == null)
        {
            Debug.LogWarning("Invalid Button Name: " + ButtonName);
            return;
        }
        
        switch (ButtonEventType)
        {
            case EButtonEvent.ButtonDown:
                SelectedButton.ButtonDownEvent += EventToBind;
                return;
            case EButtonEvent.ButtonUp:
                SelectedButton.ButtonUpEvent += EventToBind;
                return;
        }
    }

    public void BindEventToAxis(string AxisName, UnityAction<float> EventToBind)
    {
        FAxisConfig SelectedAxis = null;
        foreach (FAxisConfig Axis in AxisConfigs)
        {
            if (Axis.AxisName == AxisName)
            {
                SelectedAxis = Axis;
                break;
            }
        }

        SelectedAxis.AxisEvent += EventToBind;
        
    }

    /// <summary>
    /// Updates the mouse axis based on a project vector of the player's character position
    /// </summary>
    private void UpdateMouseAxis()
    {
        
    }
}
