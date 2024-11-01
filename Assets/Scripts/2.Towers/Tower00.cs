using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower00 : BaseTower, IFireBullet
{
    [field: SerializeField]
    public float BulletDamage { get; set; }

    [field: SerializeField]
    public float BulletSpeed { get; set; }

    [field: SerializeField]
    public Transform FireTransform { get; set; }

    private void Start()
    {        
        FireTransform = transform.GetChild(0);
    }
    
    public virtual void Fire()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (GameManager.Instance.isGameLive)
        {
            GameObject obj = GameManager.Instance.pool.Get(PoolManager.PoolType.Bullet, Id);
            obj.GetComponent<BaseBullet>().Init(BulletDamage, BulletSpeed, FireTransform);
            yield return new WaitForSeconds(attackDelay);
        }
    }
}
