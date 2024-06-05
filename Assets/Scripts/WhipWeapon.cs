using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    // 设置武器
    [SerializeField] GameObject RightWhipObject;
    [SerializeField] GameObject LeftWhipObject;
    /*[SerializeField] GameObject UpWhipObject;
    [SerializeField] GameObject DownWhipObject;

    [SerializeField] GameObject URWhipObject;
    [SerializeField] GameObject ULWhipObject;
    [SerializeField] GameObject DRWhipObject;
    [SerializeField] GameObject DLWhipObject;*/

    PlayerMove playerMove;

    [SerializeField] Vector2 whipAttackSize = new Vector2(10f, 5f);

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
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
        AttackChange(weaponStats.Count);
    }

    private void MoreRightWeapon(int WeaponCount)
    {
        switch (WeaponCount)
        {
            case 1:
                RightWhipObject.SetActive(true);
                break;
            case 2:
                RightWhipObject.SetActive(true);
                LeftWhipObject.SetActive(true);
                break;

        }
    }

    private void MoreLeftWeapon(int WeaponCount)
    {
        switch (WeaponCount)
        {
            case 1:
                LeftWhipObject.SetActive(true);
                break;
            case 2:
                LeftWhipObject.SetActive(true);
                RightWhipObject.SetActive(true);
                break;

        }
    }

    private void AttackChange(int WeaponCount)
    {
        // 根据人物朝向设计武器方向逻辑
        if (playerMove.lastHorizontalVector > 0 && playerMove.lastVerticalVector == 0)
        {
            // 释放武器
            // RightWhipObject.SetActive(true);
            MoreRightWeapon(WeaponCount);

            // 设置伤害和伤害范围
            Collider2D[] colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
            ApplyDamage(colliders);

            if (WeaponCount == 2)
            {
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
                ApplyDamage(_colliders);
            }      
        }
        // 默认武器方向
        else if (playerMove.lastVerticalVector == 0 && playerMove.lastHorizontalVector == 0)
        {
            // RightWhipObject.SetActive(true);
            MoreRightWeapon(WeaponCount);

            Collider2D[] colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0);
            ApplyDamage(colliders);
            if (WeaponCount == 2)
            {
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
                ApplyDamage(_colliders);
            }          
        }
        else if (playerMove.lastHorizontalVector < 0 && playerMove.lastVerticalVector == 0)
        {
            // LeftWhipObject.SetActive(true);
            MoreLeftWeapon(WeaponCount);

            Collider2D[] colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0);
            ApplyDamage(colliders);
            if (WeaponCount == 2)
            {
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
                ApplyDamage(_colliders);
            }
        }
        else if (playerMove.lastVerticalVector > 0 && playerMove.lastHorizontalVector == 0)
        {
            // RightWhipObject.SetActive(true);
            MoreRightWeapon(WeaponCount);

            Collider2D[] colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0);
            ApplyDamage(colliders);
            if (WeaponCount == 2)
            {
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
                ApplyDamage(_colliders);
            }
        }
        else if (playerMove.lastVerticalVector < 0 && playerMove.lastHorizontalVector == 0)
        {
            // RightWhipObject.SetActive(true);
            MoreRightWeapon(WeaponCount);

            Collider2D[] colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0);
            ApplyDamage(colliders);
            if (WeaponCount == 2)
            {
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
                ApplyDamage(_colliders);
            }
        }
        else if (playerMove.lastHorizontalVector == 1.0f && playerMove.lastVerticalVector == 1.0f)
        {
            // RightWhipObject.SetActive(true);
            MoreRightWeapon(WeaponCount);

            Collider2D[] colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0);
            ApplyDamage(colliders);
            if (WeaponCount == 2)
            {
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
                ApplyDamage(_colliders);
            }
        }
        else if (playerMove.lastHorizontalVector == -1.0f && playerMove.lastVerticalVector == 1.0f)
        {
            // LeftWhipObject.SetActive(true);
            MoreLeftWeapon(WeaponCount);

            Collider2D[] colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0);
            ApplyDamage(colliders);
            if (WeaponCount == 2)
            {
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
                ApplyDamage(_colliders);
            }
        }
        else if (playerMove.lastHorizontalVector == 1.0f && playerMove.lastVerticalVector == -1.0f)
        {
            // RightWhipObject.SetActive(true);
            MoreRightWeapon(WeaponCount);

            Collider2D[] colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0);
            ApplyDamage(colliders);
            if (WeaponCount == 2)
            {
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
                ApplyDamage(_colliders);
            }
        }
        else if (playerMove.lastHorizontalVector == -1.0f && playerMove.lastVerticalVector == -1.0f)
        {
            // LeftWhipObject.SetActive(true);
            MoreLeftWeapon(WeaponCount);

            Collider2D[] colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0);
            ApplyDamage(colliders);
            if (WeaponCount == 2)
            {
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
                ApplyDamage(_colliders);
            }
        }
    }
}
