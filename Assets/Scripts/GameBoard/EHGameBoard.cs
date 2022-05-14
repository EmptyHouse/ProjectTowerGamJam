using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EHBoardTileData
{
    public Vector2Int BoardPosition;
    public EHTowerUnit OccupyingTower;
    public bool IsOccupied => OccupyingTower != null;
}


public class EHGameBoard : EHActor
{
    #region const values
    private const float BoardTileToWorldAdjustment = 10;
    
    #endregion const values
    [SerializeField]
    private int BoardWidth = 15;
    [SerializeField]
    private int BoardHeight = 15;
    private List<EHBoardTileData> BoardTileList = new List<EHBoardTileData>();
    
    #region monobehaviour methods

    protected override void Awake()
    {
        base.Awake();
        
        // Populate Board
        for (int x = 0; x < BoardWidth; ++x)
        {
            for (int y = 0; y < BoardHeight; ++y)
            {
                EHBoardTileData BoardTile = new EHBoardTileData();
                BoardTile.BoardPosition = new Vector2Int(x, y);
                BoardTileList.Add(BoardTile);
            }
        }
    }

    #endregion monobehaviour methods

    public Vector3 BoardTileToWorldPosition(Vector2Int TilePosition)
    {
        return new Vector3(TilePosition.x * BoardTileToWorldAdjustment, 0, TilePosition.y * BoardTileToWorldAdjustment);
    }

    public Vector2Int WorldToBoardTilePosition(Vector3 WorldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt(WorldPosition.x / BoardTileToWorldAdjustment),
            Mathf.FloorToInt(WorldPosition.z / BoardTileToWorldAdjustment));
    }

    public bool GetTileAtPosition(Vector2Int BoardTilePosition, out EHBoardTileData BoardTileData)
    {
        if (!IsTilePositionValid(BoardTilePosition))
        {
            BoardTileData = default;
            return false;
        }

        BoardTileData = BoardTileList[BoardTilePosition.y * BoardWidth + BoardTilePosition.x];
        return true;
    }

    private bool IsTilePositionValid(Vector2Int BoardTilePosition)
    {
        if (BoardTilePosition.x < 0 || BoardTilePosition.x >= BoardWidth || BoardTilePosition.y < 0 ||
            BoardTilePosition.y > BoardHeight)
        {
            return false;
        }

        return true;
    }

    public bool IsTileOccupied(Vector2Int BoardTilePosition)
    {
        if (GetTileAtPosition(BoardTilePosition, out EHBoardTileData BoardtileData))
        {
            return BoardtileData.IsOccupied;
        }

        return false;
    }
    
    #region placing towers

    public bool AttemptPlaceTower(EHTowerUnit TowerUnitToConstruct, Vector3 WorldPosition, out string ErrorMessage)
    {
        ErrorMessage = "";
        Vector2Int BoardTilePosition = WorldToBoardTilePosition(WorldPosition);

        if (GetTileAtPosition(BoardTilePosition, out EHBoardTileData BoardTileData))
        {
            if (BoardTileData.IsOccupied)
            {
                ErrorMessage = "TileIsOccupied";
                return false;
            }
            PlaceTowerUnitAtTilePosition(BoardTileData, TowerUnitToConstruct);
        }

        ErrorMessage = "InvalidTilePosition";
        return false;
    }

    private void PlaceTowerUnitAtTilePosition(EHBoardTileData BoardTile, EHTowerUnit TowerToPlace)
    {
        BoardTile.OccupyingTower = Instantiate(TowerToPlace, BoardTileToWorldPosition(BoardTile.BoardPosition),
            Quaternion.identity);
    }

    public bool AttemptDestroyTower(Vector3 WorldPosition, out string ErrorMessage)
    {
        ErrorMessage = "";
        Vector2Int TilePosition = WorldToBoardTilePosition(WorldPosition);
        if (GetTileAtPosition(TilePosition, out EHBoardTileData BoardTile))
        {
            if (!BoardTile.IsOccupied)
            {
                ErrorMessage = "NoTowerAtPoint";
                return false;
            }
        }

        ErrorMessage = "InvalidTilePosition";
        return false;
    }

    private void DestroyTowerAtTilePosition(EHBoardTileData BoardTile)
    {
        Destroy(BoardTile.OccupyingTower.gameObject);
    }
    #endregion placing towers
}
