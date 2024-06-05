using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinyinhuaWeapon : WeaponBase
{
    PlayerMove PlayerMove;

    [SerializeField] GameObject bullet;

    private void Awake()
    {
        PlayerMove = GetComponentInParent<PlayerMove>();
    }

    private void Start()
    {
        PlayerMove.lastHorizontalVector = 1;
    }


    public override void Attack()
    {
        GameObject shoot = Instantiate(bullet);
        shoot.transform.position = transform.position;
        Jinyinhua shootWhip = shoot.GetComponent<Jinyinhua>();
        // 差一个追踪
        ///LRC修改
        Collider2D[] targets = new Collider2D[5];
        Physics2D.OverlapCircleNonAlloc(shoot.transform.position, 25, targets);
        GameObject enemy = null;
        foreach (var target in targets)
        {
            if (target != null && target.CompareTag("Enemy"))
            {
                enemy = target.gameObject;
                break;
            }
        }
        Vector2 dir = new Vector2(1, 0);
        if (enemy != null)
        {
            dir = enemy.transform.position - shoot.transform.position;
            dir.Normalize();
        }
        shoot.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
        //setdir = dir;
        //shootWhip.SetDirection(PlayerMove.lastHorizontalVector, PlayerMove.lastVerticalVector);
        shootWhip.SetDirection(dir.x, dir.y);
        
       // shootWhip.SetDirection(PlayerMove.lastHorizontalVector, PlayerMove.lastVerticalVector);
       ///LRC修改
        shootWhip.damage = weaponStats.damage;
    }
}
