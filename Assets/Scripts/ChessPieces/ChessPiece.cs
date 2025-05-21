using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour {
    protected int currentX;
    protected int currentY;

    public void SetPosition(int x, int y) {
        currentX = x;
        currentY = y;

        // Move the GameObject to match its board tile position
        float worldX = -4 + x + 0.5f;
        float worldY = -4 + y + 0.5f;
        transform.position = new Vector3(worldX, worldY, 0);
    }

    public Vector2Int GetPosition() {
        return new Vector2Int(currentX, currentY);
    }

    // Virtual methods to be overridden in derived piece classes
    public virtual List<BoardTile> GetAvailableMoves(BoardTile[,] board) {
        return new List<BoardTile>();
    }

    public virtual List<BoardTile> GetThreatenedTiles(BoardTile[,] board) {
        return new List<BoardTile>();
    }
}
