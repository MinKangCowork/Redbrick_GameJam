using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    public float MaxHp { get; set; }
    public float CurrentHp { get; set; }
    public void Damaged(float damage);
    public IEnumerator Dead();
}
