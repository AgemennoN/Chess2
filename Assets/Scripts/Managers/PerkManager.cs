using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public class PerkManager : MonoBehaviour {
    public static PerkManager Instance { get; private set; }

    public static List<PerkCardSO> PlayerPerks;
    public static List<PerkCardSO> EnemyPerks;

    private int perkSlots = 10;


    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
        
        PlayerPerks = new List<PerkCardSO>(perkSlots);
        EnemyPerks = new List<PerkCardSO>(perkSlots);
    }

    private void Initialize() {
        //PlayerPerks = new List<PerkCardSO>(perkSlots);
        //EnemyPerks = new List<PerkCardSO>(perkSlots);
    }


    public void AddPlayerPerk(PerkCardSO newPerk) {
        for (int i = 0; i < perkSlots; i++) {
            if (PlayerPerks[i] == null) {
                PlayerPerks[i] = newPerk;
                return;
            }
        }
    }

    public void AddEnemyPerk(PerkCardSO newPerk) {
        for (int i = 0; i < perkSlots; i++) {
            if (EnemyPerks[i] == null) {
                EnemyPerks[i] = newPerk;
                return;
            }
        }
    }


    public static void ResetStaticVariablesOnDefeat() {
        Instance = null;
        PlayerPerks = null;
        EnemyPerks = null;
    }

}
