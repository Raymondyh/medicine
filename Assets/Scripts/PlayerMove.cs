using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;
    public Animator animator;

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    [HideInInspector]
    public Vector2 movement;

    public Joystick joystick;
    
    void Update()
    {
        // 输入
        //movement.x = joystick.Horizontal;
        //movement.y = joystick.Vertical;
        //print(movement);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0f)
        {
            lastVerticalVector = 0;
            lastHorizontalVector = movement.x;
        }
        if (movement.y != 0f)
        {
            lastHorizontalVector = 0;
            lastVerticalVector = movement.y;
        }
        if (movement.x != 0f && movement.y != 0f)
        {
            lastHorizontalVector = movement.x;
            lastVerticalVector = movement.y;
        }
        if (movement.x * movement.x > 0.5f && movement.x * movement.x < 1f && movement.x > 0f)
        {
            lastVerticalVector = 0;
            lastHorizontalVector = 1f;
        }
        if (movement.x * movement.x > 0.5f && movement.x * movement.x < 1f && movement.x < 0f)
        {
            lastVerticalVector = 0;
            lastHorizontalVector = -1f;
        }
        if (movement.y * movement.y > 0.5f && movement.y * movement.y < 1f && movement.y > 0f)
        {
            lastVerticalVector = 1f;
            lastHorizontalVector = 0;
        }
        if (movement.y * movement.y > 0.5f && movement.y * movement.y < 1f && movement.y < 0f)
        {
            lastVerticalVector = -1f;
            lastHorizontalVector = 0;
        }
        // 改变动画状态机中的相应数值
        /*animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);*/ // Magnitude表示了movement这个向量的长度，也就是速度(sqr是平方)
    }

    void FixedUpdate()
    {
        // 主要移动实现 
        //movement.x = joystick.Horizontal;
        //movement.y = joystick.Vertical;
        //print(movement);
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        if (movement.x < 0)
        {
            player.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (movement.x > 0)
        {
            player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

}
