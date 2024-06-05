using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shoot : WeaponBase
{
    PlayerMove PlayerMove;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject AnotherBullet;

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

        ///LRCÐÞ¸Ä
        Vector2 dir = new Vector2(PlayerMove.lastHorizontalVector, PlayerMove.lastVerticalVector);
        dir.Normalize();

        float Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg /*- 90f*/;
        if (dir.x < 0)
            Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg /*- 270f*/;
        shoot.transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
        //print(dir);
        ///LRCÐÞ¸Ä
        ShootWhip shootWhip = shoot.GetComponent<ShootWhip>();
        AnotherShoot anotherShoot = AnotherBullet.GetComponent<AnotherShoot>();
        shootWhip.SetDirection(PlayerMove.lastHorizontalVector, PlayerMove.lastVerticalVector);

        shootWhip.damage = weaponStats.damage;
        shootWhip._isDivision = weaponStats.IsDivision;
        anotherShoot.damage = weaponStats.damage;
    }
}
