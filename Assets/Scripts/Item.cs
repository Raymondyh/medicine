using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����Buffʱ�����ȴ�����ΪItem����Ϸ���壬����Ϊ���Ӧ��Buff�������ú����Ӧ����ֵ
// ���ڴ˽�����Ӷ�Ӧ��Buff���溯���������Ƕ�Ӧ��Character��������Ӧ��������ֵ��
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int armor;

    // �Ӵ˴����BuffЧ��

    // ����
    public void EquipArmor(Character character)
    {
        character.armor += armor;
    }
    public void UnEquipArmor(Character character)
    {
        character.armor -= armor;
    }
}
