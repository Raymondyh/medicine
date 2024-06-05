using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] EnemiesManager enemiesManager;

    private bool isDead;

    // �������ֵ
    public int maxHP = 1000;
    // ��ǰ����ֵ
    public int currentHP = 1000;
    // ����Ѫ����
    [SerializeField] StatusBar hpBar;
    // ���û���ֵ
    public int armor = 0;

    // �ȼ�
    public int level = 1;
    int experience = 0;

    // ���þ�����
    [SerializeField] Slider hpSlider;
    [SerializeField] TextMeshProUGUI hpMesh;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradePanelManager UpgradePanelManager;
    
    // �������Buff��Ŀ
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
        // ��ʼ��Ѫ����
        hpBar.SetState(currentHP, maxHP);

        // ��ʼ��������
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }

    // ����ܵ��˺��󣬼���hp�����hp����0�����������Ϸ����
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
    
    // ������ʵ��
    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage < 0) { damage = 0; }

    }

    // �ָ�
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

    // ������������Ҫ�ľ���ֵ
    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    // �Ӿ���
    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    // ����
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
