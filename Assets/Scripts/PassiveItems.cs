using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;

    Character character;

    // 护甲被动
    [SerializeField] Item armorTest;


    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        Equip(armorTest);
    }

    // 为玩家加Buff的主要配置函数
    public void Equip(Item itemToEquip)
    {
        // 对Buff列表初始化
        if (items == null)
        {
            items = new List<Item>();
        }
        items.Add(itemToEquip);
        itemToEquip.EquipArmor(character);
    }

    public void UnEquip(Item itemToUnEquip)
    {

    }
}
