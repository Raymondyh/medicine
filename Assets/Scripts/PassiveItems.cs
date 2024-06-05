using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;

    Character character;

    // ���ױ���
    [SerializeField] Item armorTest;


    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        Equip(armorTest);
    }

    // Ϊ��Ҽ�Buff����Ҫ���ú���
    public void Equip(Item itemToEquip)
    {
        // ��Buff�б��ʼ��
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
