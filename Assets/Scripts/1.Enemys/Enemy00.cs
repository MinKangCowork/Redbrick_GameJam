using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy00 : BaseEnemy, IAttackable
{
    public void Attack(IDamageable target)
    {
        target.Damaged(Damage);
    }
}
