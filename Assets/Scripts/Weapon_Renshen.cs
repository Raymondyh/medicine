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
        // �����˺����˺���Χ
        Collider2D[] colliders = Physics2D.OverlapCircleAll(Renshen.transform.position, 12f * weaponStats.Range); // ��һ��Vector3����ײ�����ģ��ڶ���ΪBox�ĳ���ߣ�������Quaternion����ΪBox�ķ��򣬵��ĸ�Ϊ��ײ���Ĳ㼶��Layer(Ĭ��Ϊ���е�Layer)������queryTriggerһ���ò�����
        ApplyDamage(colliders);
        weaponStats.Range = 1;
    }
}
