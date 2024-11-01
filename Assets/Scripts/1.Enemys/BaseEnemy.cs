using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable, IMovable, IUnitInfo
{
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

    void FixedUpdate()
    {
        Move();
    }   

    public void Damaged(float damage)
    {
        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Move()
    {
        transform.Translate(Vector2.left * Speed * Time.fixedDeltaTime);
    }
}
