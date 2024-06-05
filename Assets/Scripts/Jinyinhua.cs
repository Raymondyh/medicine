using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jinyinhua : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    public int damage = 1;

    private float _timer;
    private float _timeToCold = 0.15f;

    private void Start()
    {
        _timer = _timeToCold;
    }

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y, 0f);

        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.y = scale.y * -1;
            transform.localScale = scale;
        }
    }

    bool hitDitected = false;
    private void Update()
    {
        _timer -= Time.deltaTime;

        transform.position += direction.normalized * speed * Time.deltaTime;

        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        for (int i = 0; i < hit.Length; i++)
        {
            IDamageable enemy = hit[i].GetComponent<IDamageable>();
            if (enemy != null)
            {
                if (_timer <= 0)
                {
                    MessageSystem.instance.PostMessage(damage.ToString(), hit[i].transform.position);
                    enemy.TakeDamage(damage);
                    _timer = _timeToCold;
                }
                else
                {
                    return;
                }

                hitDitected = true;
                // break;
            }
        }
        if (hitDitected) // ×ªÏò
        {
            speed -= Time.deltaTime * 60;
        }
    }
}
