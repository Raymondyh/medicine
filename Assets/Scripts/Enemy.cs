using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public GameObject effect;
    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength; // Ч������ʱ��
    private float hurtCounter;

    private Animator animator;

    Transform targetDestination;
    GameObject targetGameobject;
    Character targetCharacter;
    [SerializeField] float speed;

    Rigidbody2D rb;

    // ����Ѫ��
    [SerializeField] int hp = 100;
    // ���﹥����
    [SerializeField] int damage = 1;
    // ������侭���
    [SerializeField] GameObject experien_1;

    // ����
    [SerializeField] int Maxhp;
    [SerializeField] int Maxdamage;
    [SerializeField] int Maxscale;

    [SerializeField] int property;

    //[SerializeField] UIManager uiManager;
    private Vector3 direction;
    //private float showtime;
    /// <summary>LRC
    bool FirstIncrease;
    bool SecondIncrease;
    bool ThirdIncrease;
    bool isrestore;
    [SerializeField] SpriteRenderer spriteRenderer;
    /// </summary>
    // �޵м��
    /*[SerializeField] float invincibleTime = 2.0f;
    float invincibleTimer;
    private bool isInvincible;*/
    AudioSource ad;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        ad = this.GetComponent<AudioSource>();
        FirstIncrease = true;
        SecondIncrease = true;
        ThirdIncrease = true;
        isrestore = false;
    }
    /// <summary> 
    void reback()
    {
        damage = 1;
        hp = 100;
        this.transform.localScale = new Vector3(1, 1, 1);
        FirstIncrease = true;
        SecondIncrease = true;
        ThirdIncrease = true;
        isrestore = false;
        //print("�ظ�");
    }
    void _Increase1()
    {
        damage *= 2;
        hp *= 2;
        FirstIncrease = false;
        isrestore = true;
        this.transform.localScale *= 1.2f;
        //print("1��ǿ");
    }
    void _Increase2()
    {
        damage *= 2;
        hp *= 2;
        speed *= 2;
        SecondIncrease = false;
        isrestore = true;
        this.transform.localScale *= 1.2f;
        //print("2��ǿ");
    }
    void _Increase3()
    {
        damage *= 3;
        hp *= 4;
        ThirdIncrease = false;
        isrestore = true;
        this.transform.localScale *= 1.2f;
        //print("3��ǿ");
    }
    /// </summary>
    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        if (hurtCounter <= 0)
        {
            sp.material.SetFloat("_FlashAmount", 0);
        }
        else
        {
            hurtCounter -= Time.deltaTime;
        }

        // ���������ai�ľ���
        direction = (targetDestination.position - transform.position).normalized;

        // ai����
        if (direction.x < 0)
        {
            this.transform.rotation = new Quaternion(0f, 180f, 0f, transform.localRotation.w);
        }
        else
        {
            this.transform.rotation = new Quaternion(0f, 0f, 0f, transform.localRotation.w);
        }

        rb.velocity = direction * speed;

        // this.transform.rotation = Quaternion.LookRotation(direction);

        if (targetCharacter == null)
            targetCharacter = targetGameobject.GetComponent<Character>();
        ///LRC
        //print(targetCharacter.YinYangPercent);
        if (targetCharacter.YinYangPercent >= 25 && FirstIncrease && targetCharacter.YinYangPercent < 50)
        {

            _Increase1();
        }
        else if (targetCharacter.YinYangPercent >= 50 && SecondIncrease)
        {

            _Increase2();
        }
        else if (targetCharacter.YinYangPercent >= 75 && ThirdIncrease)
        {

            _Increase3();
        }
        if (targetCharacter.YinYangPercent <= 10 && targetCharacter.YinYangPercent >= 0 && isrestore)
        {
            reback();
        }
        if(targetCharacter.isIncrease)
        {
            hp *= 2;
        }
        ///LRC
        // �޵м��
        /*if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }*/
    }

    // ����һ�������ϵ���ײ�����ڽӴ��ö������ײ��ʱ����ÿ��֡������ 2D ����
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameobject /*&& !isInvincible*/)
        {
            Attack();
            // �޵м��
            // invincibleTimer = invincibleTime;
            // isInvincible = true;
        }
    }

    // ���﹥�����룬������ܵ�������ϵͳ���浽�����ϣ��ɹ��ﴥ��
    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameobject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(damage);
    }

    // ��ս����Ӧ�õ��˺�ϵͳ���ܵ��˺�ֱ��Ѫ��Ϊ0����ݻ�����
    public void TakeDamage(int damage)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        ///LRC
        //spriteRenderer.DOColor(Color.red, 0.2f).SetLoops(2, LoopType.Yoyo).ChangeStartValue(Color.white);
        hp -= damage;
        HurtShader();

        ad.Play();
        if (direction.x < 0 && direction.y < 0)
        {
            gameObject.transform.position += new Vector3(0.4f, 0.4f, 0);
        }
        else if (direction.x > 0 && direction.y < 0)
        {
            gameObject.transform.position += new Vector3(-0.4f, 0.4f, 0);
        }
        else if (direction.x < 0 && direction.y > 0)
        {
            gameObject.transform.position += new Vector3(0.4f, -0.4f, 0);
        }
        else if (direction.x > 0 && direction.y > 0)
        {
            gameObject.transform.position += new Vector3(-0.4f, -0.4f, 0);

        }

        if (hp < 1)
        {
            // Instantiate(effect, transform.position, Quaternion.identity);
            animator.SetTrigger("Dead");
            Invoke("Dead", 0.5f);
        }
    }

    private void HurtShader()
    {
        sp.material.SetFloat("_FlashAmount", 1);
        hurtCounter = hurtLength;
    }

    private void Dead()
    {
        GameObject Experience_1 = Instantiate(experien_1);
        Experience_1.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }

    // Զ������Ӧ�õ��˺�ϵͳ
    public void TakeDamage(int _damage, int property)//1Ϊ��0Ϊhan
    {
        if (property != this.property)
            hp -= _damage;
        if (property == this.property)
        {
            if (hp <= Maxhp)
                hp++;
            if (damage <= Maxdamage)
                damage++;
            if (this.transform.localScale.y <= Maxscale)
                this.transform.localScale *= 2;
        }

        if (hp < 1)
        {
            Destroy(gameObject);
            GameObject Experience_1 = Instantiate(experien_1);
            Experience_1.transform.position = gameObject.transform.position;
        }
    }
}
