using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance { get; private set; }

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private ArrowIndicator arrowIndicator;
    [SerializeField] private BoardInputBroadcaster boardInputBroadcaster;
    [SerializeField] private Weapon weapon;

    public PlayerPiece playerPiece; // TO DO Should be private to be more OOP
    public List<BoardTile> playerAvailableMoves; // TO DO Should be private to be more OOP
    private BoardTile[,] board;

    private TurnManager turnManager;


    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Initialize() {
        board = BoardManager.Instance.GetBoard();
        turnManager = TurnManager.Instance;

        boardInputBroadcaster.OnTileHovered += HandleTileHover;
        boardInputBroadcaster.OnTileClicked += HandleTileClick;

        turnManager.OnPlayerTurnStarted += StartPlayerTurn;
    }

    private void HandleTileHover(BoardTile tile) {
        if (!TurnManager.Instance.IsPlayerTurn())
            return;

        if (tile != null)
            if (playerAvailableMoves.Contains(tile)) {
                Vector3 from = playerPiece.GetTile().transform.position;
                Vector3 to = tile.transform.position;
                arrowIndicator.Show(from, to);
                //weapon.Aim(false);
            } else {
                arrowIndicator.Hide();
                //weapon.Aim(true);
            }
        else {
            arrowIndicator.Hide();
            //weapon.Aim(false);
        }
    }

    private void HandleTileClick(BoardTile tile, Vector3 mouseWorldPos) {
        if (!TurnManager.Instance.IsPlayerTurn())
            return;

        if (tile != null) {
            if (playerAvailableMoves.Contains(tile)) {
                arrowIndicator.Hide();
                MakeKingMovementTo(tile);
                StartCoroutine(TurnManager.Instance.StartActionPhase(true));
            } else if (tile != playerPiece.GetTile()) {
                weapon.Shoot(playerPiece.transform.position, mouseWorldPos);
                StartCoroutine(TurnManager.Instance.StartActionPhase(true));
            }
        }

    }

    private void MakeKingMovementTo(BoardTile tile) {
        if (playerAvailableMoves.Contains(tile)) {
            playerPiece.MoveToPosition(tile); // Pass callback
        }
    }

    public void SpawnPlayer() {
        // TO DO: Make it private
        GameObject obj = Instantiate(playerPrefab, transform);
        playerPiece = obj.GetComponent<PlayerPiece>();
        if (playerPiece == null) {
            Debug.LogError("Prefab does not contain a ChessPiece component.");
            Destroy(obj);
            return;
        }
        playerPiece.SetPosition(board[3, 0]);
    }

    private void StartPlayerTurn() {
        playerAvailableMoves = playerPiece.GetAvailableMoves(board);
        // Maybe Also get safeMoves(not threatened)
    }

    private void EndTurn() {
        turnManager.EndPlayerTurn();
    }
}
