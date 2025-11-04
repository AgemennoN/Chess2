using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : ChessPiece
{
    
    public override void UpdateAvailableTiles(BoardTile[,] board) {
        availableTiles = new List<BoardTile>();

        Vector2Int currentGridPosition = currentTile.GridPosition;

        // Check 8 adjacent directions
        for (int dx = -1; dx <= 1; dx++) {
            for (int dy = -1; dy <= 1; dy++) {
                // Skip the current square
                if (dx == 0 && dy == 0)
                    continue;

                int newX = currentGridPosition.x + dx;
                int newY = currentGridPosition.y + dy;

                // Bounds check
                if (newX >= 0 && newX < board.GetLength(0) && newY >= 0 && newY < board.GetLength(1)) {
                    if (board[newX,newY].GetPiece() == null)
                        availableTiles.Add(board[newX, newY]);
                }
            }
        }
    }


}
