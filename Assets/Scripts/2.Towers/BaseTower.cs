using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseTower : MonoBehaviour, IUnitInfo, IChainable
{  
    [field: SerializeField]
    public int Id { get; set; }

    [field: SerializeField]
    public float attackDelay;    

    [field: SerializeField]
    public IChainable.ESynergy SynergyType { get; set; }

    public List<IChainable> NearSynergy { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        IChainable oChain = other as IChainable;
        if (oChain != null && oChain == (IChainable)this)
        {
            if (this.SynergyType == oChain.SynergyType && !NearSynergy.Contains(oChain))
            {
                NearSynergy.Add(oChain);                
                Chain(NearSynergy.Count);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IChainable oChain = other as IChainable;
        if (oChain != null && oChain == (IChainable)this)
        {
            if (this.SynergyType == oChain.SynergyType && !NearSynergy.Contains(oChain))
            {
                NearSynergy.Remove(oChain);
                Chain(NearSynergy.Count);
            }
        }
    }
    public void Chain(int count)
    {
        if (count == 0)
            return;
        else if (count >= 3)
        {
            Debug.Log("시너지 3 이상!!!");
        }
        else if (count >= 2)
        {
            Debug.Log("시너지 2 이상!!");
        }
        else if (count >= 1)
        {
            Debug.Log("시너지 1 이상!");
        }
    }

    public void Synergy()
    {
        throw new System.NotImplementedException();
    }
}
