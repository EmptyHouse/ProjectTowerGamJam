using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHTowerPad : EHActor
{
    public enum ETowerPadState
    {
        Empty,
        Constructing,
        Occupied
    }
    
    public EHTowerUnit AttachedTower { get; private set; }
    public ETowerPadState CurrentPadState { get; private set; }
    #region monobehaviour methods
    
    #endregion monobehaviour methods
    
    /// <summary>
    /// Construct a tower at this pad and begin the build process
    /// </summary>
    /// <param name="TowerToConstruct"></param>
    public void ConstructTower(string TowerNameToConstruct)
    {
        
    }

    public bool CanConstructAtPad()
    {
        return CurrentPadState == ETowerPadState.Empty;
    }

    public bool CanSellTowerAtPad()
    {
        return CurrentPadState == ETowerPadState.Occupied;
    }
}
