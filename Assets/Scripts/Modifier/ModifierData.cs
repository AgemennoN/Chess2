using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyModifierData {
    public EnemyType enemyType;
    public int healthChange;
    public int speedChange;
    public List<MovementPattern> movementPatterns;
    public List<MovementPattern> threatPatterns;

    public EnemyModifierData(EnemyTypeSO enemyTypeSO) {
        enemyType = enemyTypeSO.enemyType;
        healthChange = 0;
        speedChange = 0;

        movementPatterns = new List<MovementPattern>(enemyTypeSO.movementPatterns);
        threatPatterns = new List<MovementPattern>(enemyTypeSO.threatPatterns);
    }
}

[System.Serializable]
public class WeaponModifierData {
    public int firePowerChange;     // Number of bullets fired per shot
    public int fireRangeChange;     // Bullet travel distance
    public int fireArcChange;       // Spread angle in degrees

    public int magCapacityChange;         // Max shells loaded into weapon
    public int maxReserveAmmoChange;      // Max reserve shells player can carry
    public int reloadAmountChange;        // Shells loaded per reload action
}