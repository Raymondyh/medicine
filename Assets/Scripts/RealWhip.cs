using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealWhip : WeaponBase
{
    PlayerMove PlayerMove;

    [SerializeField] GameObject bianzi;

    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);


    private void Awake()
    {
        PlayerMove = GetComponentInParent<PlayerMove>();
    }

    private void Start()
    {
        PlayerMove.lastHorizontalVector = 1;
    }

    public void ChangRange()
    {
        bianzi.transform.localScale = new Vector3(bianzi.transform.localScale.x * weaponStats.Range, bianzi.transform.localScale.y * weaponStats.Range, 1);
    }

    public override void Attack()
    {
        ChangRange();

        if (PlayerMove.lastHorizontalVector > 0)
        {
            bianzi.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(bianzi.transform.position, whipAttackSize, 0); // 第一个Vector3是碰撞的中心，第二个为Box的长宽高，第三个Quaternion类型为Box的方向，第四个为碰撞检测的层级的Layer(默认为所有的Layer)，最后的queryTrigger一般用不到。
            ApplyDamage(colliders);
        }      
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
}
