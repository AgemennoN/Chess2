using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPiece : ChessPiece {
    private int maxHealth;
    private int currenHealth;
    private int cooldownToMove;

    private void Awake() {
        currenHealth = maxHealth;
    }

}