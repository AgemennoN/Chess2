using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour {

    protected BoardTile currentTile;
    [SerializeField] protected List<BoardTile> availableTiles;
    [SerializeField] protected List<BoardTile> threatenedTiles;
    protected float movementDuration = 0.5f;

    public void SetPosition(BoardTile tile) {
        if (currentTile != null) {
            currentTile.SetPiece(null); // Remove from old tile
        }
        transform.position = tile.transform.position;
        currentTile = tile;
        tile.SetPiece(this); // Update new tile  
        // TO DO: Might use event that listens when a piece is placed on a Tile to be More OOP maybe?
    }

    public void MoveToPosition(BoardTile tile) {
        if (currentTile != null) {
            currentTile.SetPiece(null); // Remove from old tile
            TurnManager.Instance.RegisterAction(MoveToPositionPhysically(tile.transform.position, movementDuration));
        } else {
            transform.position = tile.transform.position;
        }
        currentTile = tile;
        tile.SetPiece(this); // Update new tile  
    }

    private IEnumerator MoveToPositionPhysically(Vector3 targetPos, float duration) {
        Vector3 startPos = transform.position;
        float time = 0f;

        while (time < duration) {
            transform.position = Vector3.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos; // Ensure it lands exactly
    }

    public BoardTile GetTile() { return currentTile; }

    // Virtual methods to be overridden in derived piece classes
    public virtual void UpdateAvailableTiles(BoardTile[,] board) {
    }

    public virtual void UpdateThreatenedTiles(BoardTile[,] board) {
    }

    public virtual List<BoardTile> GetAvailableTiles() {
        return availableTiles;
    }
    public virtual List<BoardTile> GetThreatenedTiles() {
        return threatenedTiles;
    }
}
