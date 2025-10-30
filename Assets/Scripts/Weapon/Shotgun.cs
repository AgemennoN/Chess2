using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shotgun : Weapon
{
    //[SerializeField] private AimIndicator aimIndicator;
    //[SerializeField] private ArrowIndicator aimIndicator;

    public override void Shoot(Vector3 from, Vector3 to) {
        if (weaponData == null) return;

        Vector2 direction = (to - from);
        direction.Normalize();

        float baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float halfArc = weaponData.fireArc / 2f;

        int bulletsRemaining = weaponData.firePower;
        TurnManager.Instance.RegisterAction(WaitForBulletsToFinish(() => bulletsRemaining == 0));

        for (int i = 0; i < weaponData.firePower; i++) {
            float randomAngle = UnityEngine.Random.Range(-halfArc, halfArc);
            Quaternion rotation = Quaternion.Euler(0, 0, baseAngle + randomAngle);

            Bullet bullet = bulletPool.GetBullet().GetComponent<Bullet>();
            bullet.transform.position = from;
            bullet.transform.rotation = rotation;
            bullet.gameObject.SetActive(true);

            bullet.Initialize(
                weaponData.bulletSpeed,
                weaponData.bulletDamage,
                weaponData.fireRange,
                bulletPool,
                i
            );

            //TO DO: Check if this method prevents memory leak
            Action<Bullet> onFinish = null;
            onFinish = (b) => {
                bulletsRemaining--;
                bullet.OnBulletFinished -= onFinish;
            };
            bullet.OnBulletFinished += onFinish;
        }

    }

    private IEnumerator WaitForBulletsToFinish(Func<bool> allDoneCondition) {
        // TO DO: Is this the best placement for this IEnumerator?
        yield return new WaitUntil(allDoneCondition);
    }

    public override void Aim(bool enable) {
        //if (enable) {
        //    aimIndicator.Show(new Vector3(),new Vector3());
        //} else {
        //    aimIndicator.Hide();
        //}
        throw new System.NotImplementedException();
    }


    protected override void Reload() {
        throw new System.NotImplementedException();
    }
}
