using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerInformationUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI firePowerTMPro;
    [SerializeField] private TextMeshProUGUI fireRangeTMPro;
    [SerializeField] private TextMeshProUGUI fireArcTMPro;
    private WeaponStats weaponStats = null;

    public IEnumerator NewFloorPreperation() {
        GetWeaponStats();
        SetTexts();
        yield break;
    }

    public void Show() {
        if (weaponStats == null) return;
        gameObject.SetActive(true);
    }

    public void Hide() {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
    }

    private void GetWeaponStats() {
        Weapon weapon = PlayerManager.Instance.GetWeapon();
        if (weapon != null) {
            weaponStats = weapon.GetWeaponStats();
        }
    }

    private void SetTexts() {
        firePowerTMPro.text = weaponStats.firePower.ToString();
        fireRangeTMPro.text = $"{weaponStats.fireMaxRange} - {weaponStats.fireMinRange}";
        fireArcTMPro.text = weaponStats.fireArc.ToString() + "°";
    }

}
