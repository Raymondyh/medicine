using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDispose : MonoBehaviour
{
    Transform playerTransform;
    float maxDistance = 80f;

    private void Start()
    {
        playerTransform = GameManager.instance.playerTransform;
    }

    private void Update()
    {
        // 当距离超过maxDistance设置的数值，自动销毁游戏物体
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
