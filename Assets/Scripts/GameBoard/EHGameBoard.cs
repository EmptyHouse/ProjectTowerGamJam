using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct FBoardTileData
{
    public Vector2Int BoardPosition;
    public EHTowerUnit OccupyingTower;
    public bool IsOccupied => OccupyingTower != null;
}


public class EHGameBoard : EHActor
{
    #region const values
    public const int BoardWidth = 10;
    public const int BoardHeight = 10;
    #endregion const values
    
    
}
