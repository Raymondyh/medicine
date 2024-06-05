using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;

    public weaponStats weaponStats;

    float timer;


    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0f)
        {
            Attack();
            timer = weaponStats.timeToAttack;
        }
    }

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;

        weaponStats = new weaponStats(wd.stats.damage, wd.stats.timeToAttack, wd.stats.Range, wd.stats.CunZaiTime, wd.stats.Area, wd.stats.Count, wd.stats.IsDivision);
    }

    public abstract void Attack();

    public virtual void PostDamage(int damage, Vector3 targetPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), targetPosition);
    }

    internal void Upgrade(UpgradeData upgradeData)
    {
        weaponStats.Sum(upgradeData.weaponUpgradeStates);
        weaponStats.Multiply(upgradeData.weaponUpgradeStates);
    }
}
