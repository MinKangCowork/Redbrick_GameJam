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

    // 컴포넌트
    protected Animator animator;
    protected Rigidbody rb;
    protected Collider coll;
    protected override void Awake()
    {
        base.Awake();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();

        NearSynergy = new List<IChainable> { this }; // 자기 자신을 초기 리스트에 추가
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
            Debug.Log("0인 왕따");
            return;
        }
        else if (count >= 4)
        {
            Debug.Log("4인 시너지 이상!!!");
        }
        else if (count >= 3)
        {
            Debug.Log("3인 시너지 발생");
        }
        else if (count >= 2)
        {
            Debug.Log("2인 시너지 발생");
        }
    }

    public IEnumerator Dead()
    {

        gameObject.layer = Mathf.RoundToInt(Mathf.Log(deadLayerMask.value, 2));
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
