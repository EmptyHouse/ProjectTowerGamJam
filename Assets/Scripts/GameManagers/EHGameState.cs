using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHGameState : MonoBehaviour
{
    public EHGameBoard GameBoard { get; private set; }

    public void SetGameBoard(EHGameBoard GameBoard)
    {
        this.GameBoard = GameBoard;
    }
}
