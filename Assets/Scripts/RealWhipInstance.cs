using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealWhipInstance : MonoBehaviour
{
    Vector3 direction;

    public int damage = 1;

    public float Range = 1f;

    private float timer;
    private float timeToDelete = 1f;

    private void Awake()
    {
        timer = timeToDelete;
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

    private void Update()
    {
        transform.position += direction.normalized * Time.deltaTime;

        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 1f * Range);
        foreach (Collider2D c in hit)
        {
            Enemy enemy = c.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                break;
            }
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
            timer = timeToDelete;
        }
    }
}