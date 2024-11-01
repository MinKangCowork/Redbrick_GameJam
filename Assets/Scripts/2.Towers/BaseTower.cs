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

    [SerializeField]
    private int synergyCurrent;

    private void Awake()
    {
        NearSynergy = new List<IChainable> { this }; // 자기 자신을 초기 리스트에 추가
    }


    public void SynergyUpdate(int count)
    {
        synergyCurrent = count;
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

    public void ChainEnterCheck(IChainable oChain)
    {
        if (this.SynergyType == oChain.SynergyType && !NearSynergy.Contains(oChain))
        {
            Debug.Log("Enter");
            NearSynergy.Add(oChain);
            oChain.NearSynergy.Add(this); // 상대방의 리스트에도 자신을 추가
            SynergyUpdate(NearSynergy.Count);
            oChain.SynergyUpdate(oChain.NearSynergy.Count); // 상대방의 시너지 업데이트
        }
    }

    public void ChainExitCheck(IChainable oChain)
    {
        if (this.SynergyType == oChain.SynergyType && NearSynergy.Contains(oChain))
        {
            Debug.Log("Exit");
            NearSynergy.Remove(oChain);
            oChain.NearSynergy.Remove(this); // 상대방의 리스트에서도 자신을 제거
            SynergyUpdate(NearSynergy.Count);
            oChain.SynergyUpdate(oChain.NearSynergy.Count); // 상대방의 시너지 업데이트
        }
    }
}
