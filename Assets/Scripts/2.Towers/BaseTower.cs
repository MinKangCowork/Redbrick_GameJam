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
            Debug.Log("0인 왕따");
            return;
        }
        else if (count >= 4)
        {
            Debug.Log("4인 시너지 이상!!!");
        }
        else if (count >= 3)
        {
            Debug.Log("3인 시너지 발생");
        }
        else if (count >= 2)
        {
            Debug.Log("2인 시너지 발생");
        }
    }

    public abstract void BatchAfterRun();    
}
