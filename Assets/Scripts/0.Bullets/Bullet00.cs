using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet00 : BaseBullet
{
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ��ü�� BaseEnemy ��ũ��Ʈ�� ������ Ȯ��
        BaseEnemy enemy = other.GetComponent<BaseEnemy>();
        if (enemy != null)
        {
            Debug.Log("Hit! :" + enemy.name);
            // ���� ��� ������ ����
            IDamageable target = enemy;
            Attack(target);
        }
        else
            Debug.Log("NO Enemy");
    }
}
