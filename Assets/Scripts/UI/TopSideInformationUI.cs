using System.Collections.Generic;
using UnityEngine;

public class TopSideInformationUI : MonoBehaviour {

    private Weapon weapon;

    [SerializeField] private Transform magTransform;
    [SerializeField] private Transform reserveBeltTransform;

    [SerializeField] private Sprite ammoSprite;
    [SerializeField] private Sprite emptyAmmoSprite;

    [SerializeField] private Sprite shieldSprite; // later
    [SerializeField] private Sprite emptyShieldSprite; //later

    private List<AmmoUI> magAmmoPool;
    private List<AmmoUI> reserveAmmoPool;
    private int magCapacity;
    private int maxReserveAmmo;


    private void ShootAnimation(int currentMag) {
        for (int i = 0; i < magAmmoPool.Count; i++) {
            bool filled = i < currentMag;
            magAmmoPool[i].SetFilled(filled);
        }
    }

    private void ReloadMagAnimation(int currentMag, int currentReserve) {
        for (int i = 0; i < magCapacity; i++)
            magAmmoPool[i].SetFilled(i < currentMag);
        for (int i = 0; i < maxReserveAmmo; i++)
            reserveAmmoPool[i].SetFilled(i < currentReserve);
    }

    private void RegenerateReserveAnimation(int currentReserve) {
        for (int i = 0; i < reserveAmmoPool.Count; i++)
            reserveAmmoPool[i].SetFilled(i < currentReserve);
    }

    private void GetWeaponFromPlayerManager() {
        weapon = PlayerManager.Instance.GetWeapon();
        weapon.OnShoot += ShootAnimation;
        weapon.OnReloadMag += ReloadMagAnimation;
        weapon.OnRegenerateReserve+= RegenerateReserveAnimation;

        WeaponDataSO weaponData = weapon.GetWeaponData();
        magCapacity = weaponData.magCapacity;
        maxReserveAmmo = weaponData.maxReserveAmmo;
        CreatePools();
    }

    private void CreatePools() {
        magAmmoPool = new();
        for (int i = 0; i < magCapacity; i++) {
            magAmmoPool.Add(AmmoUI.Create(magTransform, ammoSprite, emptyAmmoSprite));
        }
        reserveAmmoPool = new();
        for (int i = 0; i < maxReserveAmmo; i++) {
            reserveAmmoPool.Add(AmmoUI.Create(reserveBeltTransform, ammoSprite, emptyAmmoSprite));
        }
    }

    private void ResetPools() {
        foreach (AmmoUI ui in magAmmoPool) {
            Destroy(ui.gameObject);
        }
        foreach (AmmoUI ui in reserveAmmoPool) {
            Destroy(ui.gameObject);
        }
        magAmmoPool = new();
        reserveAmmoPool = new();
    }

    public void NewFloorPreperation() {
        GetWeaponFromPlayerManager();
        gameObject.SetActive(true);
    }

    public void OnPlayerWin() {
        weapon.OnShoot -= ShootAnimation;
        weapon.OnReloadMag -= ReloadMagAnimation;
        weapon.OnRegenerateReserve -= RegenerateReserveAnimation;
        weapon = null;
        ResetPools();
        gameObject.SetActive(false);
    }
}
