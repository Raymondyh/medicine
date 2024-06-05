using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [SerializeField] Transform bar;
    // [SerializeField] SpriteRenderer appear;

    /*private void Update()
    {
        
    }*/

    // 根据血量更新HP的UI
    public void SetState(int current, int max)
    {
        float state = (float)current;
        state /= max;
        if (state < 0f)
        {
            state = 0f;
        }
        bar.transform.localScale = new Vector3(state, 1f, 1f);
    }
}
