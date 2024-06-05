using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    [SerializeField] [Range(0f, 1f)] float probability;

    // 地图随机生成物（可设置生成点）
    public void Spawn()
    {
        if (Random.value < probability)
        {
            GameObject go = Instantiate(toSpawn, transform.position, Quaternion.identity);
        }
    }
}
