using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWhip : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    public int damage = 1;
    //[SerializeField] Shoot _shoot;
    [SerializeField] GameObject bullet;

    public bool _isDivision;

    private float _timer = 0f;
    private float _timeToCold = 1f;
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
            IDamageable enemy = c.GetComponent<IDamageable>();
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
        if (hitDitected && _isDivision)
        {
            //_isDivision = false;
            GameObject shoot_1 = Instantiate(bullet);
            GameObject shoot_2 = Instantiate(bullet);
            shoot_1.transform.position = transform.position;
            shoot_2.transform.position = transform.position;
            AnotherShoot _shoot_1 = shoot_1.GetComponent<AnotherShoot>();
            AnotherShoot _shoot_2 = shoot_2.GetComponent<AnotherShoot>();

            if (direction.x < 0)
            {
                Vector3 vector3 = _shoot_1.transform.position;
                vector3.x -= 8f;
                _shoot_1.transform.position = vector3;

                Vector3 _vector3 = _shoot_2.transform.position;
                _vector3.x -= 8f;
                _shoot_2.transform.position = _vector3;
            }
            else
            {
                Vector3 vector3 = _shoot_1.transform.position;
                vector3.x += 8f;
                _shoot_1.transform.position = vector3;

                Vector3 _vector3 = _shoot_2.transform.position;
                _vector3.x += 8f;
                _shoot_2.transform.position = _vector3;
            }

            Quaternion rot1 = Quaternion.AngleAxis(60f, Vector3.forward);
            Vector3 dir1 = rot1 * direction;
            _shoot_1.SetDirection(dir1.x, dir1.y);

            Quaternion rot2 = Quaternion.AngleAxis(-60f, Vector3.forward);
            Vector3 dir2 = rot2 * direction;
            _shoot_2.SetDirection(dir2.x, dir2.y);
            //if (transform.localPosition.x > 0 && transform.localPosition.y == 0)
            //{
            //    _shoot_1.SetDirection(1f, 1f);
            //    _shoot_2.SetDirection(1f, -1f);
            //}
            //else if (transform.localPosition.x > 0 && transform.localPosition.y > 0)
            //{
            //    _shoot_1.SetDirection(0f, 1f);
            //    _shoot_2.SetDirection(1f, 0f);
            //}
            //else if (transform.localPosition.x > 0 && transform.localPosition.y < 0)
            //{
            //    _shoot_1.SetDirection(1f, 0f);
            //    _shoot_2.SetDirection(0f, -1f);
            //}
            //else if (transform.localPosition.x == 0 && transform.localPosition.y > 0)
            //{
            //    _shoot_1.SetDirection(-1f, 1f);
            //    _shoot_2.SetDirection(1f, 1f);
            //}
            //else if (transform.localPosition.x < 0 && transform.localPosition.y > 0)
            //{
            //    _shoot_1.SetDirection(-1f, 0f);
            //    _shoot_2.SetDirection(0f, 1f);
            //}
            //else if (transform.localPosition.x < 0 && transform.localPosition.y < 0)
            //{
            //    _shoot_1.SetDirection(0f, -1f);
            //    _shoot_2.SetDirection(-1f, 0f);
            //}
            //else if (transform.localPosition.x == 0 && transform.localPosition.y < 0)
            //{
            //    _shoot_1.SetDirection(-1f, -1f);
            //    _shoot_2.SetDirection(1f, -1f);
            //}
            //else if (transform.localPosition.x < 0 && transform.localPosition.y == 0)
            //{
            //    _shoot_1.SetDirection(-1f, -1f);
            //    _shoot_2.SetDirection(-1f, 1f);
            //}
            _isDivision = false;
            Destroy(gameObject);
        }
        else if(hitDitected && !_isDivision)
        {
            Destroy(gameObject);
        }
    }
}
