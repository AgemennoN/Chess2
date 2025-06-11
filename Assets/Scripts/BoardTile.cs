using Unity.VisualScripting;
using UnityEngine;

public class BoardTile : MonoBehaviour {
    
    public static BoardTile Create(float tileSize, int positionX, int positionY, Sprite sprite, ChessPiece chessPiece=null, GameObject parent=null) {
        GameObject tileObject = new GameObject($"Tile_{positionX}_{positionY}");
        BoardTile tile = tileObject.AddComponent<BoardTile>();
        tile.positionX = positionX;
        tile.positionY = positionY;
        tile.tileSize = tileSize;

        tile.spriteRenderer = tile.gameObject.AddComponent<SpriteRenderer>();
        tile.spriteRenderer.sprite = sprite;
        tile.transform.localScale = new Vector3(4.5f, 4.5f);

        tile.SetPosition();
        tile.SetPiece(chessPiece);
        if (chessPiece != null) {
            chessPiece.SetPosition(tile);
        }
        if (parent != null) {
            tile.transform.SetParent(parent.transform);
        }
        return tile;
    }

    private int positionX;
    private int positionY;
    private float tileSize;
    private SpriteRenderer spriteRenderer;
    public ChessPiece pieceOnIt; // TO DO: Should it be public? Or is there a better option to be more OOP

    public ChessPiece GetPiece() => pieceOnIt;

    public void SetPiece(ChessPiece piece) {
        pieceOnIt = piece;
    }

    private void SetPosition() {
        // To do (minor): instead of using a constant as -4 get board size and use -BoardSize/2
        float worldPositionX = (-4 + positionX) * tileSize + tileSize/2;
        float worldPositionY = (-4 + positionY) * tileSize + tileSize/2;
        transform.position = new Vector3(worldPositionX, worldPositionY, 0);
    }

    public Vector2Int GetPosition() {
        return new Vector2Int(positionX, positionY);
    }

}
