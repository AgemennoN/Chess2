using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyPiece : ChessPiece {
    [SerializeField] protected EnemyTypeSO enemyTypeSO;
    [SerializeField] protected int currenHealth;
    [SerializeField] protected int cooldownToMove;
    [SerializeField] protected bool readyToMove = false;

    protected List<BoardTile> availableTiles;

    public System.Action<EnemyPiece> OnDeath;

    private void Awake() {
        if (enemyTypeSO != null) {
            currenHealth = enemyTypeSO.maxHealth;
            cooldownToMove = UnityEngine.Random.Range(2, enemyTypeSO.speed + 1);

        }
    }

    public void TakeAction() {
        if (cooldownToMove > 1) {
            ReduceCooldown();
        } 
        if (cooldownToMove == 1) {
            availableTiles = GetAvailableMoves(BoardManager.Board);
            if (availableTiles.Count != 0) {
                if (cooldownToMove == 1 && readyToMove == false) {
                    GetReadyToMove();
                } else { // Stop Shaking and MOVE
                    StopReadyingToMove();
                    MoveToPosition(DecideMovementTile(availableTiles));
                    cooldownToMove = enemyTypeSO.speed; // Reset Cooldown
                    Debug.Log($"GameObject {gameObject.name} Taking Action maxHealth: {enemyTypeSO.maxHealth}, speed: {enemyTypeSO.speed}");
                    
                }
            } else { // No Available Movement
                if (readyToMove == true) {
                    StopReadyingToMove();
                }
            }
        }
    }

    private void ReduceCooldown() {
        cooldownToMove -= 1;
    }

    private void GetReadyToMove() { // starts shaking
        readyToMove = true;
        // Start shaking animation
    }

    private void StopReadyingToMove() { // Stop shaking
        readyToMove = false;
        // Stop shaking animation
    }

    protected virtual BoardTile DecideMovementTile(List<BoardTile> availableTiles) {
        if (availableTiles.Count > 0) {
            int randomIndex = UnityEngine.Random.Range(0, availableTiles.Count);
            BoardTile randomTile = availableTiles[randomIndex];
            return randomTile;
        } else {
            return null;
        }
    }

    public void TakeDamage(int amount) {
        currenHealth -= amount;
        if (currenHealth <= 0) {
            Die();
        }
    }
    private void Die() {
        // play death animation
        OnDeath?.Invoke(this);
        Destroy(gameObject);
    }

    public EnemyTypeSO GetEnemyTypeSO() {
        return enemyTypeSO;
    }

}