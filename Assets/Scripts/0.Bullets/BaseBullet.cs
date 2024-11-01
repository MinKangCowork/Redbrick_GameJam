using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour, IMovable, IAttackable, IUnitInfo
{
    [field: SerializeField]
    public float Speed { get; set; }

    [field: SerializeField]
    public float Damage { get; set; }
    public int Id { get; set; }

    public int per;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    protected virtual void FixedUpdate()
    {
        Move();
    }

    public virtual void Attack(IDamageable target)
    {
        target.Damaged(Damage);
    }

    public virtual void Move()
    {
        rb.velocity = Vector2.right * Speed;
    }

    public virtual void Init(float damage, float speed, Transform parent)
    {
        this.Damage = damage;
        this.Speed = speed;
        transform.parent = parent;
        transform.position = parent.position;
    }
}
