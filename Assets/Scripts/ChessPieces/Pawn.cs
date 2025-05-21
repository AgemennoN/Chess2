using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pawn : EnemyPiece {

    private void Awake() {
        health = 3;
        cooldownToMove = 4;
    }

    public override List<BoardTile> GetAvailableMoves(BoardTile[,] board) {
        List<BoardTile> availableTiles = new List<BoardTile>();

        if (currentX > 0) {
            if (board[currentX - 1,currentY].pieceOnIt == null) {
                // TO DO:  Check if it is in Thereataned Tiles of the Player's
                availableTiles.Add(board[currentX - 1, currentY]);
            }
        }
        return availableTiles;
    }

    public override List<BoardTile> GetThreatenedTiles(BoardTile[,] board) {
        List<BoardTile> threatenedTiles = new List<BoardTile>();
        if (currentX > 0) {
            if (currentY > 0) {
                threatenedTiles.Add(board[currentX - 1, currentY - 1]);
            }
            if (currentY < board.Length - 1) {
                threatenedTiles.Add(board[currentX - 1, currentY + 1]);
            }
        }
        return threatenedTiles;
    }
}
