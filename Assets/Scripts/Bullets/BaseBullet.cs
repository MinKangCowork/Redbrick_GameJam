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
        transform.Translate(Vector3.right * Speed * Time.fixedDeltaTime); 
    }

    public abstract void Init(Transform parent);
}
