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
        NearSynergy = new List<IChainable> { this }; // �ڱ� �ڽ��� �ʱ� ����Ʈ�� �߰�
    }


    public void SynergyUpdate(int count)
    {
        synergyCurrent = count;
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

    public void ChainEnterCheck(IChainable oChain)
    {
        if (this.SynergyType == oChain.SynergyType && !NearSynergy.Contains(oChain))
        {
            Debug.Log("Enter");
            NearSynergy.Add(oChain);
            oChain.NearSynergy.Add(this); // ������ ����Ʈ���� �ڽ��� �߰�
            SynergyUpdate(NearSynergy.Count);
            oChain.SynergyUpdate(oChain.NearSynergy.Count); // ������ �ó��� ������Ʈ
        }
    }

    public void ChainExitCheck(IChainable oChain)
    {
        if (this.SynergyType == oChain.SynergyType && NearSynergy.Contains(oChain))
        {
            Debug.Log("Exit");
            NearSynergy.Remove(oChain);
            oChain.NearSynergy.Remove(this); // ������ ����Ʈ������ �ڽ��� ����
            SynergyUpdate(NearSynergy.Count);
            oChain.SynergyUpdate(oChain.NearSynergy.Count); // ������ �ó��� ������Ʈ
        }
    }
}
