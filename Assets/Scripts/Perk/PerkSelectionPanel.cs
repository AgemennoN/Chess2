using System.Collections;
using TMPro;
using UnityEngine;



public class PerkSelectionPanel : MonoBehaviour {

    [SerializeField] private PerkChoiseBox perkChoise_1;
    [SerializeField] private PerkChoiseBox perkChoise_2;

    public void UpdateChoiseBoxes(
        PerkCardSO playerPerk_1, PerkCardSO enemyPerk_1,
        PerkCardSO playerPerk_2, PerkCardSO enemyPerk_2) {

        perkChoise_1.UpdatePerks(playerPerk_1, enemyPerk_1);
        perkChoise_2.UpdatePerks(playerPerk_2, enemyPerk_2);
    }

}
