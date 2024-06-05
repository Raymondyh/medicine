using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 在添加Buff时，首先创建名为Item的游戏物体，改名为相对应的Buff并且设置好相对应的数值
// 再在此界面添加对应的Buff增益函数，别忘记对应到Character中添加相对应的属性数值。
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int armor;

    // 从此处添加Buff效果

    // 护甲
    public void EquipArmor(Character character)
    {
        character.armor += armor;
    }
    public void UnEquipArmor(Character character)
    {
        character.armor -= armor;
    }
}
