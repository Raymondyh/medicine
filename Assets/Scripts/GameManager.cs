 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ������ҵĵ���
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform playerTransform;
}
