using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    private EnemyManager enemyManager;
    private int roundNumber;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        Initialize();
        StartGame();
    }

    public void Initialize() {
        enemyManager = EnemyManager.Instance;
        roundNumber = 0;
    }

    public void StartGame() {
        enemyManager.spawnEnemies();
    }

}
