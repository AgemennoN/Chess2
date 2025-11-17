using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerInformationUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI firePowerTMPro;
    [SerializeField] private TextMeshProUGUI fireRangeTMPro;
    [SerializeField] private TextMeshProUGUI fireArcTMPro;

    public IEnumerator NewFloorPreperation() {
        WeaponDataSO weaponData = GetWeaponDataFromPlayerManager();
        SetTexts(weaponData);
        yield break;
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
    }

    private WeaponDataSO GetWeaponDataFromPlayerManager() {
        return PlayerManager.Instance.GetWeapon().GetWeaponData();
    }

    private void SetTexts(WeaponDataSO weaponData) {
        firePowerTMPro.text = weaponData.firePower.ToString();
        fireRangeTMPro.text = $"{weaponData.fireMaxRange} - {weaponData.fireMinRange}";
        fireArcTMPro.text = weaponData.fireArc.ToString() + "°";
    }

}
