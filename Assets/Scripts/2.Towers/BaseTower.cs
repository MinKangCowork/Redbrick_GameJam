using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseTower : ChainableBase, IUnitInfo, IBatchable
{  
    [field: SerializeField]
    public int Id { get; set; }

    [field: SerializeField]
    public float attackDelay;    
   
    protected override void Awake()
    {
        base.Awake();
    }

    public override void SynergyUpdate(int count)
    {
        SynergyCurrent = count;
        if (count == 0)
        {
            Debug.Log("0�� �յ�");
            return;
        }
        else if (count >= 4)
        {
            Debug.Log("4�� �ó��� �̻�!!!");
        }
        else if (count >= 3)
        {
            Debug.Log("3�� �ó��� �߻�");
        }
        else if (count >= 2)
        {
            Debug.Log("2�� �ó��� �߻�");
        }
    }

    public abstract void BatchAfterRun();    
}
