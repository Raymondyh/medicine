using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] EnemiesManager enemiesManager;

    private bool isDead;

    // 最大生命值
    public int maxHP = 1000;
    // 当前生命值
    public int currentHP = 1000;
    // 设置血量条
    [SerializeField] StatusBar hpBar;
    // 设置护甲值
    public int armor = 0;

    // 等级
    public int level = 1;
    int experience = 0;

    // 设置经验条
    [SerializeField] Slider hpSlider;
    [SerializeField] TextMeshProUGUI hpMesh;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradePanelManager UpgradePanelManager;
    
    // 设置玩家Buff项目
    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;

    [SerializeField] List<UpgradeData> acquiredUpgrades;

    WeaponManager WeaponManager;

    /// <summary>LRC
    [SerializeField] YinYangMananger yy;
    public int YinYangPercent;
    /// </summary>
    public bool isIncrease;
    int maxleve;
    private void Awake()
    {
        WeaponManager = GetComponent<WeaponManager>();
        isIncrease = false;
        maxleve = 60;
        hpSlider.maxValue = 1000;
    }

    private void Start()
    {
        // 初始化血量条
        hpBar.SetState(currentHP, maxHP);

        // 初始化经验条
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }

    // 玩家受到伤害后，减少hp，如果hp到达0，销毁玩家游戏物体
    public void TakeDamage(int damage)
    {
        if (isDead == true) { return; }

        ApplyArmor(ref damage);

        currentHP -= damage;
        hpSlider.value -= damage;
        hpMesh.text = currentHP.ToString();
        if (currentHP <= 0)
        {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }
        hpBar.SetState(currentHP, maxHP);
    }
    
    // 防御力实现
    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage < 0) { damage = 0; }

    }

    // 恢复
    public void Heal(int amount)
    {
        if (currentHP <= 0)
        {
            return;
        }

        currentHP += amount;
        if (currentHP >= maxHP)
        {
            currentHP = maxHP;
        }
        
        hpBar.SetState(currentHP, maxHP);
    }

    // 设置升级所需要的经验值
    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    // 加经验
    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    // 升级
    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP&&level<=maxleve)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if (selectedUpgrades == null) { selectedUpgrades = new List<UpgradeData>(); }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(3));

        UpgradePanelManager.OpenPanel(selectedUpgrades);   
        experience -= TO_LEVEL_UP;
        level += 1;
        enemiesManager.spawnTime -= 0.1f;
        if (enemiesManager.spawnTime <= 1f)
        {
            enemiesManager.spawnTime = 1f;
        }
        if (level >= 5)
        {
            enemiesManager.isAI_1 = true;
        }
        if(level>=8)
        {
            enemiesManager.isAI_2 = true;
        }
        if(level>=15)
        {
            enemiesManager.isAI_3 = true;
        }
        if(level>=30)
        {
            isIncrease = true;
        }
        experienceBar.SetLevelText(level);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }
        bool flag = true;
        upgradeList.Capacity = 3;
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, upgrades.Count);
            for (int j = 0; j < i; j++)
            {
                if (upgradeList[j] == upgrades[index])
                {
                    i--;
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                upgradeList.Add(upgrades[index]);
            }
            flag = true;
            //upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }

        return upgradeList;
    }

    internal void AddUpgradesIntoTheListOfAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
        this.upgrades.AddRange(upgradesToAdd);
    }

    public void Upgrade(int selectedUpgradeId)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeId];

        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }

        switch (upgradeData.upgradeType)
        {
            case UpgradeType.weaponUpgrade:
                WeaponManager.UpgradeWeapon(upgradeData);
                YinYangPercent = yy.Persent();
                break;
            case UpgradeType.ItemUpgrade:
                ///LRC
                WeaponManager.IncreaseItem(upgradeData);
                YinYangPercent = yy.Persent();
                ///
                break;
            case UpgradeType.WeaponUnlock:
                WeaponManager.AddWeapon(upgradeData.weaponData, upgradeData);
                YinYangPercent = yy.Persent();
                break;
            //case UpgradeType.ItemUnlock:
              //  break;
        }

        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }
}
