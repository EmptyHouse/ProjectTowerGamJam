using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EHGameBoard : EHActor
{
    #region const values
    private const float BoardTileToWorldAdjustment = 10;
    
    #endregion const values
    [SerializeField]
    private int BoardWidth = 15;
    [SerializeField]
    private int BoardHeight = 15;

    private HashSet<EHUnitBuildPad> AllActiveBuildPads = new HashSet<EHUnitBuildPad>();
    private EHUnitBuildPad CurrentActiveBuildPad;

    #region monobehaviour methods
    protected void Start()
    {
        EHGameInstance.Instance.GameState.SetGameBoard(this);
    }

    #endregion monobehaviour methods
}
