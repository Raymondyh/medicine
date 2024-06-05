using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTimer : MonoBehaviour
{
    float timeToDisable = 0.5f;
    float timer;

    private void OnEnable()
    {
        timer = timeToDisable;
    }

    private void LateUpdate()
    {
        // 短剑持续时间，时间到后消除
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
