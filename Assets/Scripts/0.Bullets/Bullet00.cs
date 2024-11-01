using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet00 : BaseBullet
{
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 객체가 BaseEnemy 스크립트를 가진지 확인
        BaseEnemy enemy = other.GetComponent<BaseEnemy>();
        if (enemy != null)
        {
            Debug.Log("Hit! :" + enemy.name);
            // 적일 경우 데미지 적용
            IDamageable target = enemy;
            Attack(target);
        }
        else
            Debug.Log("NO Enemy");
    }
}
