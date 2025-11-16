using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInformationUI : MonoBehaviour {


    [Header("Childeren Objects")]
    [SerializeField] private Transform pieceName;
    [SerializeField] private Transform icon;
    [SerializeField] private Transform health;
    [SerializeField] private Transform pattern;
    [SerializeField] private Transform speed;

    [Header("Templates")]
    [SerializeField] private Transform heartTemplate;
    [SerializeField] private Transform emptyHeartTemplate;

    [SerializeField] private Transform speedTemplate;
    [SerializeField] private Transform emptySpeedTemplate;

    private int heartPoolLimit = 15;
    private List<Transform> heartPool;
    private List<Transform> EmptyHeartPool;

    private int speedPoolLimit = 10;
    private List<Transform> speedPool;
    private List<Transform> emptySpeedPool;


    private TextMeshProUGUI pieceNameTMPro;
    private Image pieceImage;

    //[SerializeField] private PatternViewer patternViewer;


    public void Initialize() {
        pieceNameTMPro = pieceName.GetComponent<TextMeshProUGUI>();
        pieceImage = icon.Find("image").GetComponent<Image>();

        CreatePools();
    }

    private void CreatePools() {
        heartPool = new();
        for (int i = 0; i < heartPoolLimit; i++) {
            heartPool.Add(Instantiate(heartTemplate, health));
            heartPool[i].gameObject.SetActive(false);
        }
        EmptyHeartPool = new();
        for (int i = 0; i < heartPoolLimit; i++) {
            EmptyHeartPool.Add(Instantiate(emptyHeartTemplate, health));
            EmptyHeartPool[i].gameObject.SetActive(false);
        }
        speedPool = new();
        for (int i = 0; i < speedPoolLimit; i++) {
            speedPool.Add(Instantiate(speedTemplate, speed));
            speedPool[i].gameObject.SetActive(false);
        }
        emptySpeedPool = new();
        for (int i = 0; i < speedPoolLimit; i++) {
            emptySpeedPool.Add(Instantiate(emptySpeedTemplate, speed));
            emptySpeedPool[i].gameObject.SetActive(false);
        }
    }

    public void ShowEnemy(EnemyPiece enemyPiece) {
        ResetPools();

        SetPieceName(enemyPiece.enemyTypeSO.pieceName);
        SetIcon(enemyPiece.enemyTypeSO.sprite);

        EnemyStats stats = enemyPiece.GetEnemyStats();
        SetHealth(stats);
        SetSpeed(stats);

        gameObject.SetActive(true);
    }

    public void Hide() {
        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
            ResetPools();
        }
    }

    private void SetPieceName(string pieceName) {
        pieceNameTMPro.text = pieceName;
    }
    private void SetIcon(Sprite sprite) {
        pieceImage.sprite = sprite;
    }

    private void SetHealth(EnemyStats stats) {
        for (int i = 0; i < stats.currentHealth; i++) {
            heartPool[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < (stats.maxHealth - stats.currentHealth); i++) {
            EmptyHeartPool[i].gameObject.SetActive(true);
        }
    }

    private void SetSpeed(EnemyStats stats) {
        for (int i = 0; i < stats.cooldownToMove; i++) {
            speedPool[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < (stats.speed - stats.cooldownToMove); i++) {
            emptySpeedPool[i].gameObject.SetActive(true);
        }
    }

    private void ResetPools() {
        for (int i = 0; i < heartPoolLimit; i++) {
            heartPool[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < heartPoolLimit; i++) {
            EmptyHeartPool[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < speedPoolLimit; i++) {
            speedPool[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < speedPoolLimit; i++) {
            emptySpeedPool[i].gameObject.SetActive(false);
        }
    }

}
