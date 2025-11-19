using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PerkInformationUI : MonoBehaviour {

    [SerializeField] private PerkCardUI perkUITemplate;
    [SerializeField] private Transform playerPerksUI;
    [SerializeField] private Transform enemyPerksUI;

    private List<PerkCardUI> playerPerkUIList;
    private List<PerkCardUI> enemyPerkUIList;

    private int perkLimit = 10;

    public void Initialize() {
        playerPerkUIList = new List<PerkCardUI>();
        for (int i = 0; i < perkLimit; i++) {
            playerPerkUIList.Add(PerkCardUI.Create(playerPerksUI, null, perkUITemplate));
        }
        enemyPerkUIList = new List<PerkCardUI>();
        for (int i = 0; i < perkLimit; i++) {
            enemyPerkUIList.Add(PerkCardUI.Create(enemyPerksUI, null, perkUITemplate));
        }
    }

    public void AddPlayerPerk(PerkCardSO perk) {
        foreach(PerkCardUI perkUI in playerPerkUIList) {
            if (perkUI.GetPerk() == null) {
                perkUI.SetPerk(perk);
                return;
            }
        }
    }

    public void AddEnemyPerk(PerkCardSO perk) {
        foreach (PerkCardUI perkUI in enemyPerkUIList) {
            if (perkUI.GetPerk() == null) {
                perkUI.SetPerk(perk);
                return;
            }
        }
    }

    public void NewFloorPreperation() {
        gameObject.SetActive(true);
    }

    public void OnPlayerWin() {
        gameObject.SetActive(false);
    }


}
