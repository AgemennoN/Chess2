using UnityEngine;

public class PieceFactory : MonoBehaviour {
    public GameObject kingPrefab;
    public GameObject queenPrefab;
    public GameObject rookPrefab;
    public GameObject knightPrefab;
    public GameObject bishopPrefab;
    public GameObject pawnPrefab;


    // Usage    factory.CreatePiece<Pawn>(board, 4, 4, factory.pawnPrefab);
    public T CreatePiece<T>(BoardTile[,] board, int x, int y, GameObject prefab) where T : EnemyPiece {
        if (board[x, y].pieceOnIt != null) {
            Debug.Log($"board[{x},{y}] already has a piece.");
            return null;
        }

        GameObject obj = Instantiate(prefab);
        T piece = obj.GetComponent<T>();
        piece.SetPosition(x, y);
        board[x, y].pieceOnIt = piece;
        return piece;
    }
}
