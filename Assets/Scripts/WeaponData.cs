using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class weaponStats
{
    public int damage;
    public float timeToAttack;
    public float Range;
    public float CunZaiTime;
    public Vector2 Area;
    public int Count;
    public bool IsDivision;

    public weaponStats(int damage, float timeToAttack, float Range, float CunZaiTime, Vector2 Area, int Count, bool isDivision)
    {
        this.damage = damage;
        //加不加时间变成负数
        this.timeToAttack = timeToAttack;
        this.Range = Range;
        this.CunZaiTime = CunZaiTime;
        this.Area = Area;
        this.Count = Count;
        if (IsDivision && !isDivision)
        {
            return;
        }
        else
        {
            this.IsDivision = isDivision;
        }
    }

    internal void Sum(weaponStats weaponUpgradeStats)
    {
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.CunZaiTime += weaponUpgradeStats.CunZaiTime;
        this.Count += weaponUpgradeStats.Count;
        if (IsDivision)
        {
            return;
        }
        else
        {
            this.IsDivision = weaponUpgradeStats.IsDivision;
        }
    }

    internal void Multiply(weaponStats weaponUpgradeStats)
    {
        this.damage *= weaponUpgradeStats.damage;
        this.Range *= weaponUpgradeStats.Range;
    }
}

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public weaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradeData> upgrades;
}
