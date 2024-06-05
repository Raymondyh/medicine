using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum YinYanngType
{
    Yin, Yang, YinAndYang
}

[CreateAssetMenu]
public class ItemBase : ScriptableObject
{
    // Start is called before the first frame update
    //public string Name;
    public YinYanngType _type;
    public int IncreaseHP;
    public int IncreaseArmor;
    //[TextArea]public string Intro;
    //public Sprite icon;
    public int value;
    public void EquipArmor(Character character)
    {
        character.armor += IncreaseArmor;
    }
    public void EquipHP(Character character)
    {
        character.currentHP += IncreaseHP;
    }

}
