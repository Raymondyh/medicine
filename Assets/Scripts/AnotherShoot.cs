using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherShoot : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    public int damage = 1;
    //[SerializeField] Shoot _shoot;

    private float _timer = 0f;
    private float _timeToCold = 2f;
    //private bool _IsAttack;
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
        transform.position += direction.normalized * speed * Time.deltaTime;

        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        foreach (Collider2D c in hit)
        {
            Enemy enemy = c.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (_timer <= 0)
                {
                    ///LRC
                    MessageSystem.instance.PostMessage(damage.ToString(), c.transform.position);
                    ///LRC
                    enemy.TakeDamage(damage);
                    hitDitected = true;
                    _timer = _timeToCold;
                    //break;
                }
                else
                {
                    return;
                }
                _timer -= Time.deltaTime;

            }
        }
        if (hitDitected)
        {
            Destroy(gameObject);
        }
    }
}
