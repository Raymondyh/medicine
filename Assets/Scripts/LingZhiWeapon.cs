using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingZhiWeapon : WeaponBase
{
    PlayerMove PlayerMove;

    [SerializeField] GameObject bullet;

    private void Awake()
    {
        PlayerMove = GetComponentInParent<PlayerMove>();
    }

    private GameObject SpawnBullet(GameObject bullet)
    {
        Vector3 position = GenerateRandomPosition();
        position += PlayerMove.transform.position;

        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = position;

        //newBullet.transform.parent = transform;

        return newBullet;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        position.x = UnityEngine.Random.Range(-weaponStats.Area.x, weaponStats.Area.x);
        position.y = UnityEngine.Random.Range(-weaponStats.Area.y + 50f,weaponStats.Area.y);
        position.z = 0f;

        return position;
    }

    public override void Attack()
    {
        GameObject shoot = SpawnBullet(bullet);
        LingZhi shootWhip = shoot.GetComponent<LingZhi>();

        shootWhip.damage = weaponStats.damage;
        shootWhip.Range = weaponStats.Range;
        shootWhip.CunZaiTime = weaponStats.CunZaiTime;
    }
} 
