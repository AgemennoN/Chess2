using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance { get; private set; }
    [SerializeField] private GameObject playerPrefab;
    private BoardTile[,] board;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        board = BoardManager.Instance.GetBoard();
    }

    public void SpawnPlayer() {
        GameObject obj = Instantiate(playerPrefab);
        ChessPiece piece = obj.GetComponent<ChessPiece>();
        if (piece == null) {
            Debug.LogError("Prefab does not contain a ChessPiece component.");
            Destroy(obj);
            return;
        }
        piece.SetPosition(board[3, 0]);
    }

}
