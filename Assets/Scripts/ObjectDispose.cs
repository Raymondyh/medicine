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
        // �����볬��maxDistance���õ���ֵ���Զ�������Ϸ����
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}