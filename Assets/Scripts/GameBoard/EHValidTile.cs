using System;
using UnityEngine;

public enum ETileState
{
    None,
    Valid,
    Invalid,
}

public class EHValidTile : MonoBehaviour
{
    [SerializeField]
    private Color ValidColor = new Color(1, 0, 0, .7f);
    [SerializeField]
    private Color InvalidColor = new Color(0, 1, 1, .7f);
    [SerializeField]
    private Color NoneColor = new Color(0, 0, 0, 0);

    private SpriteRenderer TileSprite;
    private Vector2Int CurrentTileLocation;
    private ETileState CurrentTileState;

    private void Awake()
    {
        TileSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetValidTile(ETileState TileState, Vector3 WorldPosition)
    {
        Vector2Int TilePosition = EHGameBoard.WorldToBoardTilePosition(WorldPosition);
        if (CurrentTileState == TileState && TilePosition == CurrentTileLocation)
        {
            return;
        }
        switch (TileState)
        {
            case ETileState.None:
                TileSprite.color = NoneColor;
                break;
            case ETileState.Valid:
                TileSprite.color = ValidColor;
                break;
            case ETileState.Invalid:
                TileSprite.color = InvalidColor;
                break;
        }
    }
}
