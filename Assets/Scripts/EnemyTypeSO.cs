using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTypeSO", menuName = "Scriptable Objects/EnemyTypeSO")]
public class EnemyTypeSO : ScriptableObject
{
    public EnemyType enemyType;
    public int maxHealth;
    public int speed;

    // public List<Vector2Int> movementPattern;
    // Prefabs
}
