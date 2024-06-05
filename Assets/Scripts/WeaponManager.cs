using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // 在这里面添加武器及其属性

    [SerializeField] Transform weaponObjectsContainer;
    [SerializeField] WeaponData startingWeapon;

    /// <summary>LRC
    [SerializeField] YinYangMananger yy;
    /// </summary>

    List<WeaponBase> weapons;

    private void Awake()
    {
        weapons = new List<WeaponBase>();
    }

    private void Start()
    {
        AddWeapon(startingWeapon);
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();

        weaponBase.SetData(weaponData);
        weapons.Add(weaponBase);

        Character level = GetComponent<Character>();
        if (level != null)
        {
            level.AddUpgradesIntoTheListOfAvailableUpgrades(weaponData.upgrades);
        }
    }
    /// <summary>
    /// LRC
    /// </summary>
    /// <param name="weaponData"></param>
    /// <param name="upgradeData"></param>
    public void AddWeapon(WeaponData weaponData, UpgradeData upgradeData)
    {
        AddWeapon(weaponData);
        if (upgradeData.itemBase._type == YinYanngType.Yang)
        {
            //upgradeData.itemBase.EquipHP(weaponObjectsContainer.GetComponentInParent<Character>());
            yy.IncreaseYang(upgradeData.itemBase.value);
        }
        else if (upgradeData.itemBase._type == YinYanngType.Yin)
        {
            //upgradeData.itemBase.EquipArmor(weaponObjectsContainer.GetComponentInParent<Character>());
            yy.IncreaseYin(upgradeData.itemBase.value);
        }
    }

    internal void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
        ///LRC
        if (upgradeData.itemBase._type == YinYanngType.Yang)
        {
            //upgradeData.itemBase.EquipHP(weaponObjectsContainer.GetComponentInParent<Character>());
            yy.IncreaseYang(upgradeData.itemBase.value);
        }
        else if (upgradeData.itemBase._type == YinYanngType.Yin)
        {
            //upgradeData.itemBase.EquipArmor(weaponObjectsContainer.GetComponentInParent<Character>());
            yy.IncreaseYin(upgradeData.itemBase.value);
        }
        ///LRC
    }

    public void IncreaseItem(UpgradeData upgradeData)
    {
        //print("YES");
        if (upgradeData.itemBase._type == YinYanngType.Yin)
        {
            upgradeData.itemBase.EquipHP(weaponObjectsContainer.GetComponentInParent<Character>());

            yy.IncreaseYin(upgradeData.itemBase.value);
        }

        else if (upgradeData.itemBase._type == YinYanngType.Yang)
        {
            upgradeData.itemBase.EquipArmor(weaponObjectsContainer.GetComponentInParent<Character>());
            yy.IncreaseYang(upgradeData.itemBase.value);
        }
        else
        {
            upgradeData.itemBase.EquipHP(weaponObjectsContainer.GetComponentInParent<Character>());
            yy.IncreaseYang(upgradeData.itemBase.value);
            upgradeData.itemBase.EquipArmor(weaponObjectsContainer.GetComponentInParent<Character>());
            yy.IncreaseYin(upgradeData.itemBase.value);
        }

    }
}
