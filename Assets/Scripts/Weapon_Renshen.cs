using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Renshen : WeaponBase
{
    [SerializeField] GameObject Renshen;

    private void Start()
    {
        Renshen.SetActive(true);
    }


    public void ChangRange()
    {
        Renshen.transform.localScale = new Vector3(Renshen.transform.localScale.x * weaponStats.Range, Renshen.transform.localScale.y * weaponStats.Range, 1);
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
                PostDamage(weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage);
            }
        }
    }

    public override void Attack()
    {
        ChangRange();
        // 设置伤害和伤害范围
        Collider2D[] colliders = Physics2D.OverlapCircleAll(Renshen.transform.position, 12f * weaponStats.Range); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
        ApplyDamage(colliders);
        weaponStats.Range = 1;
    }
}
