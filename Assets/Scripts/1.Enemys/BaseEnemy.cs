using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : ChainableBase, IDamageable, IMovable, IUnitInfo, IAttackable
{
    public LayerMask deadLayerMask;
    [field: SerializeField]
    public int Id { get; set; }

    [field: SerializeField]
    public float Speed { get; set; }

    [field: SerializeField]
    public float MaxHp { get; set; }

    [field: SerializeField]
    public float CurrentHp { get; set; }

    [field: SerializeField]
    public float Damage { get; set; }

    [field: SerializeField]
    public bool IsDetection { get; set; }

    public bool isLive;

    // ������Ʈ
    protected Animator animator;
    protected Rigidbody rb;
    protected Collider coll;
    protected override void Awake()
    {
        base.Awake();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();

        NearSynergy = new List<IChainable> { this }; // �ڱ� �ڽ��� �ʱ� ����Ʈ�� �߰�
    }
    protected virtual void FixedUpdate()
    {
        if (!isLive || !GameManager.Instance.isGameLive || IsDetection)
        {
            rb.velocity = Vector3.zero;
            return;
        }
                
        Move();
    }   
    
    protected virtual void Update()
    {
        Animation();
        if (Input.GetKeyDown(KeyCode.Space))
            Damaged(CurrentHp);
    }
    public void Damaged(float damage)
    {
        if (!isLive)
            return;
        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            isLive = false;
            animator.SetTrigger("doDead");
            StartCoroutine(Dead());
        }
    }

    public void Move()
    {
        rb.velocity = Vector2.left * Speed;        
    }
    public void Attack(IDamageable target)
    {
        target.Damaged(Damage);
    }
    
    public void Animation()
    {
        animator.SetBool("isWalk", rb.velocity.x >= 0);
        animator.SetBool("isAttack", IsDetection);
    }

    public override void SynergyUpdate(int count)
    {
        SynergyCurrent = count;
        if (count == 0)
        {
            Debug.Log("0�� �յ�");
            return;
        }
        else if (count >= 4)
        {
            Debug.Log("4�� �ó��� �̻�!!!");
        }
        else if (count >= 3)
        {
            Debug.Log("3�� �ó��� �߻�");
        }
        else if (count >= 2)
        {
            Debug.Log("2�� �ó��� �߻�");
        }
    }

    public IEnumerator Dead()
    {

        gameObject.layer = Mathf.RoundToInt(Mathf.Log(deadLayerMask.value, 2));
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
