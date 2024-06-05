using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestory : MonoBehaviour
{
    [SerializeField] GameObject healthPickUp;
    [SerializeField] [Range(0f, 1f)] float chance = 1f;
    bool isQuitting = false;

    // 修复destory的小bug
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void CheckDrop()
    {
        if (isQuitting) { return; }

        // 物体被摧毁时掉落回复道具
        if (Random.value < chance)
        {
            Transform t = GameObject.Instantiate(healthPickUp).transform;
            t.transform.position = transform.position;
        }
    }
}
