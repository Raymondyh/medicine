using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingZhi : MonoBehaviour
{
    public int damage;

    public float Range;

    public float CunZaiTime;

    private float timer;

    private float _timer = 0f;

    private float _timeToCold = 0.5f;

    public void ChangRange()
    {
        transform.localScale = new Vector3(transform.localScale.x * Range, transform.localScale.y * Range, 1);
    }

    private void Start()
    {
        timer = CunZaiTime;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        timer -= Time.deltaTime;

        ChangRange();

        Collider2D[] hit = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 25f), 12f * Range);
        Range = 1;

        if (_timer <= 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                IDamageable e = hit[i].GetComponent<IDamageable>();
                if (e != null)
                {
                    MessageSystem.instance.PostMessage(damage.ToString(), hit[i].transform.position);
                    e.TakeDamage(damage);
                    _timer = _timeToCold;
                }
            }
        }
        

        if (timer <= 0f)
        {
            Destroy(gameObject);
            timer = CunZaiTime;
        }
        
    }
}
