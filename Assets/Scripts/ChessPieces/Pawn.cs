using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pawn : EnemyPiece {

    public override List<BoardTile> GetAvailableMoves(BoardTile[,] board) {
        // TO DO: GetPosition is not logical to be in local methods and called in every use FIX
        Vector2Int position = currentTile.GetPosition();
        List<BoardTile> availableTiles = new List<BoardTile>();
        if (position.x > 0) {
            if (board[position.x - 1,position.y].pieceOnIt == null) {
                // TO DO:  Check if it is in Thereataned Tiles of the Player's
                availableTiles.Add(board[position.x - 1, position.y]);
            }
        }
        return availableTiles;
    }

    public override List<BoardTile> GetThreatenedTiles(BoardTile[,] board) {
        Vector2Int position = currentTile.GetPosition();
        List<BoardTile> threatenedTiles = new List<BoardTile>();
        if (position.x > 0) {
            if (position.y > 0) {
                threatenedTiles.Add(board[position.x - 1, position.y - 1]);
            }
            if (position.y < board.Length - 1) {
                threatenedTiles.Add(board[position.x - 1, position.y + 1]);
            }
        }
        return threatenedTiles;
    }
}
