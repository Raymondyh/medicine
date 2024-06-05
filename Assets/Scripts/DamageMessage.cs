using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] float timeToLeave = 2f;
    float timer;

    private void OnEnable()
    {
        timer = timeToLeave;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
