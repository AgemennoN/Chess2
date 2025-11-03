using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class BoardTile : MonoBehaviour {
    
    public static BoardTile Create(Vector2Int gridPos, float spriteScaleFactor, Sprite sprite, Transform parent = null) {
        GameObject obj = new GameObject($"Tile_{gridPos.x}_{gridPos.y}");
        BoardTile tile = obj.AddComponent<BoardTile>();

        tile.gridPositionX = gridPos.x;
        tile.gridPositionY = gridPos.y;

        tile.SetWorldPosition(sprite, spriteScaleFactor);
        tile.CreateSprite(sprite, spriteScaleFactor);
        tile.gameObject.layer = LayerMask.NameToLayer("BoardTileLayer"); // TO DO: Using string is sad
        tile.CreateCollider();


        if (parent != null)
            tile.transform.SetParent(parent, false);

        return tile;
    }

    private int gridPositionX;
    private int gridPositionY;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private PlayerManager playerManager;
    private ChessPiece pieceOnIt;

    public Vector2Int GridPosition => new Vector2Int(gridPositionX, gridPositionY);
    public ChessPiece GetPiece() => pieceOnIt;

    public void SetPiece(ChessPiece piece) {
        pieceOnIt = piece;
    }

    private void SetWorldPosition(Sprite sprite, float spriteScaleFactor) {
        float tileWorldSize = sprite.bounds.size.x * spriteScaleFactor;
        float offsetX = (BoardManager.Instance.BoardWidth - 1) * tileWorldSize / 2f;
        float offsetY = (BoardManager.Instance.BoardHeight - 1) * tileWorldSize / 2f;
        transform.position = new Vector3(
            gridPositionX * tileWorldSize - offsetX,
            gridPositionY * tileWorldSize - offsetY,
            0
        );
    }

    private void CreateSprite(Sprite sprite, float spriteScaleFactor) {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingLayerName = "ChessBoard";
        transform.localScale = Vector3.one * spriteScaleFactor;
    }

    private void CreateCollider() {
        boxCollider = gameObject.AddComponent<BoxCollider2D>();

        Bounds spriteBounds = spriteRenderer.sprite.bounds;
        boxCollider.size = spriteBounds.size;
        boxCollider.offset = spriteBounds.center;
    }

}
