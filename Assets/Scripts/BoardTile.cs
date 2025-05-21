using UnityEngine;

public class BoardTile : MonoBehaviour {
    
    public static BoardTile Create(float tileSize, int positionX, int positionY, ChessPiece chessPiece=null) {
        GameObject tileObject = new GameObject($"Tile_{positionX}_{positionY}");
        BoardTile tile = tileObject.AddComponent<BoardTile>();
        tile.positionX = positionX;
        tile.positionY = positionY;
        tile.tileSize = tileSize;

        tile.SetPosition();
        tile.pieceOnIt = chessPiece;
        if (chessPiece != null) {
            chessPiece.SetPosition(positionX, positionY);
        }

        return tile;
    }

    private int positionX;
    private int positionY;
    private float tileSize;
    private Sprite sprite;
    public ChessPiece pieceOnIt;

    private void SetPosition() {
        float worldPositionX = (-4 + positionX) * tileSize + tileSize/2;
        float worldPositionY = (-4 + positionY) * tileSize + tileSize/2;
        transform.position = new Vector3(worldPositionX, worldPositionY, 0);

    }

    public Vector2 GetTileCenter() {
        return new Vector2(transform.position.x, transform.position.y);
    }
}
