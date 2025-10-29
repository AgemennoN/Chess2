using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponDataSO weaponData;

    private int currentMag;         // Current number of shells currently loaded in the weapon
    private int currentReserveAmmo; // Current number of reserve shells available for reloading

    protected virtual void Start() {
        currentMag = weaponData.magCapacity;
        currentReserveAmmo = weaponData.maxReserveAmmo;
    }

    protected abstract void Shoot();
    public abstract void Aim(bool enable);
    protected abstract void Reload();

}
