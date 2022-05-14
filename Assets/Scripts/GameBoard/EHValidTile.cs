using System;
using UnityEngine;

public enum ETileState
{
    Valid,
    Invalid,
}

public class EHValidTile : MonoBehaviour
{
    [SerializeField]
    private Color ValidColor = new Color(1, 0, 0, .7f);
    [SerializeField]
    private Color InValidColor = new Color(0, 1, 1, .7f);

    private SpriteRenderer TileSprite;

    private void Awake()
    {
        TileSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetValidTile(ETileState TileState, Vector3 WorldPosition)
    {
        switch (TileState)
        {
            case ETileState.Valid:

                break;
            case ETileState.Invalid:

                break;
        }
    }
}
