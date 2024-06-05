 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 设置玩家的单例
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform playerTransform;
}
