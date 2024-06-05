using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    // ��������
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
        // �������ﳯ��������������߼�
        if (playerMove.lastHorizontalVector > 0 && playerMove.lastVerticalVector == 0)
        {
            // �ͷ�����
            // RightWhipObject.SetActive(true);
            MoreRightWeapon(WeaponCount);

            // �����˺����˺���Χ
            Collider2D[] colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0); // ��һ��Vector3����ײ�����ģ��ڶ���ΪBox�ĳ���ߣ�������Quaternion����ΪBox�ķ��򣬵��ĸ�Ϊ��ײ���Ĳ㼶��Layer(Ĭ��Ϊ���е�Layer)������queryTriggerһ���ò�����
            ApplyDamage(colliders);

            if (WeaponCount == 2)
            {
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // ��һ��Vector3����ײ�����ģ��ڶ���ΪBox�ĳ���ߣ�������Quaternion����ΪBox�ķ��򣬵��ĸ�Ϊ��ײ���Ĳ㼶��Layer(Ĭ��Ϊ���е�Layer)������queryTriggerһ���ò�����
                ApplyDamage(_colliders);
            }      
        }
        // Ĭ����������
        else if (playerMove.lastVerticalVector == 0 && playerMove.lastHorizontalVector == 0)
        {
            // RightWhipObject.SetActive(true);
            MoreRightWeapon(WeaponCount);

            Collider2D[] colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0);
            ApplyDamage(colliders);
            if (WeaponCount == 2)
            {
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // ��һ��Vector3����ײ�����ģ��ڶ���ΪBox�ĳ���ߣ�������Quaternion����ΪBox�ķ��򣬵��ĸ�Ϊ��ײ���Ĳ㼶��Layer(Ĭ��Ϊ���е�Layer)������queryTriggerһ���ò�����
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
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0); // ��һ��Vector3����ײ�����ģ��ڶ���ΪBox�ĳ���ߣ�������Quaternion����ΪBox�ķ��򣬵��ĸ�Ϊ��ײ���Ĳ㼶��Layer(Ĭ��Ϊ���е�Layer)������queryTriggerһ���ò�����
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
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // ��һ��Vector3����ײ�����ģ��ڶ���ΪBox�ĳ���ߣ�������Quaternion����ΪBox�ķ��򣬵��ĸ�Ϊ��ײ���Ĳ㼶��Layer(Ĭ��Ϊ���е�Layer)������queryTriggerһ���ò�����
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
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // ��һ��Vector3����ײ�����ģ��ڶ���ΪBox�ĳ���ߣ�������Quaternion����ΪBox�ķ��򣬵��ĸ�Ϊ��ײ���Ĳ㼶��Layer(Ĭ��Ϊ���е�Layer)������queryTriggerһ���ò�����
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
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // ��һ��Vector3����ײ�����ģ��ڶ���ΪBox�ĳ���ߣ�������Quaternion����ΪBox�ķ��򣬵��ĸ�Ϊ��ײ���Ĳ㼶��Layer(Ĭ��Ϊ���е�Layer)������queryTriggerһ���ò�����
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
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0); // ��һ��Vector3����ײ�����ģ��ڶ���ΪBox�ĳ���ߣ�������Quaternion����ΪBox�ķ��򣬵��ĸ�Ϊ��ײ���Ĳ㼶��Layer(Ĭ��Ϊ���е�Layer)������queryTriggerһ���ò�����
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
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(LeftWhipObject.transform.position, whipAttackSize, 0); // ��һ��Vector3����ײ�����ģ��ڶ���ΪBox�ĳ���ߣ�������Quaternion����ΪBox�ķ��򣬵��ĸ�Ϊ��ײ���Ĳ㼶��Layer(Ĭ��Ϊ���е�Layer)������queryTriggerһ���ò�����
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
                Collider2D[] _colliders = Physics2D.OverlapBoxAll(RightWhipObject.transform.position, whipAttackSize, 0); // ��һ��Vector3����ײ�����ģ��ڶ���ΪBox�ĳ���ߣ�������Quaternion����ΪBox�ķ��򣬵��ĸ�Ϊ��ײ���Ĳ㼶��Layer(Ĭ��Ϊ���е�Layer)������queryTriggerһ���ò�����
                ApplyDamage(_colliders);
            }
        }
    }
}
