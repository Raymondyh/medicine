using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    weaponUpgrade,
    ItemUpgrade,
    WeaponUnlock,
    //ItemUnlock
}

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string Name;
    public Sprite icon;
    [TextArea]public string text;

    /// <summary>LRC
     public ItemBase itemBase;
    /// </summary>
    
    public WeaponData weaponData;
    public weaponStats weaponUpgradeStates;
}
