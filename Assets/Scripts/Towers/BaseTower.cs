using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseTower : MonoBehaviour, IUnitInfo
{
    [field: SerializeField]
    public int Id { get; set; }

    [field: SerializeField]
    public float Damage { get; set; }
    public float attackDelay;
    public Transform firePos;

    protected virtual void Awake()
    {
        firePos = transform.GetChild(1); // firePosition
    }
    protected virtual void OnEnable()
    {
        AttackStart();
    }

    protected virtual void OnDisable()
    {
        StopAllCoroutines();
    }

    protected virtual void AttackStart()
    {
        StartCoroutine(AttackRoutine());
    }

    protected virtual IEnumerator AttackRoutine()
    {
        while (GameManager.Instance.isGameLive)
        {            
            GameObject obj = GameManager.Instance.pool.Get(PoolManager.PoolType.Bullet, Id);            
            obj.transform.parent = firePos.transform;
            obj.transform.position = firePos.transform.position;
            yield return new WaitForSeconds(attackDelay);
        }
    }
}
