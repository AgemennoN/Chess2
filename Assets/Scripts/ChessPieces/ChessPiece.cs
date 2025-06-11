using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour {

    protected BoardTile currentTile;

    public void SetPosition(BoardTile tile) {
        if (currentTile != null)
            currentTile.SetPiece(null); // Remove from old tile

        currentTile = tile;
        tile.SetPiece(this); // Update new tile  
        // TO DO: Might use event that listens when a piece is placed on a Tile to be More OOP maybe?
        transform.position = tile.transform.position;
    }

    // Virtual methods to be overridden in derived piece classes
    public virtual List<BoardTile> GetAvailableMoves(BoardTile[,] board) {
        return new List<BoardTile>();
    }

    public virtual List<BoardTile> GetThreatenedTiles(BoardTile[,] board) {
        return new List<BoardTile>();
    }
}
