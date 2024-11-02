using System.Collections.Generic;
using UnityEngine;

public abstract class ChainableBase : MonoBehaviour, IChainable
{
    [field: SerializeField]
    public IChainable.ESynergy SynergyType { get; set; }

    public List<IChainable> NearSynergy { get; set; }

    [field: SerializeField]
    public int SynergyCurrent { get; set; }

    protected virtual void Awake()
    {
        NearSynergy = new List<IChainable> { this }; // �ڱ� �ڽ��� �ʱ� ����Ʈ�� �߰�
    }

    
    public void ChainEnterCheck(IChainable oChain)
    {
        if (this.SynergyType == oChain.SynergyType && !NearSynergy.Contains(oChain))
        {
            NearSynergy.Add(oChain);
            oChain.NearSynergy.Add(this); // ������ ����Ʈ���� �ڽ��� �߰�
            UpdateSynergyForGroup(); // �ó��� �׷� ������Ʈ
        }
    }

    public void ChainExitCheck(IChainable oChain)
    {
        if (this.SynergyType == oChain.SynergyType && NearSynergy.Contains(oChain))
        {
            NearSynergy.Remove(oChain);
            oChain.NearSynergy.Remove(this); // ������ ����Ʈ������ �ڽ��� ����
            UpdateSynergyForGroup(); // �ó��� �׷� ������Ʈ            
        }
    }

    // �ó��� �׷� ��ü�� ������Ʈ�ϴ� �޼���
    public void UpdateSynergyForGroup()
    {
        HashSet<IChainable> visited = new HashSet<IChainable>();
        Queue<IChainable> queue = new Queue<IChainable>();

        queue.Enqueue(this);
        visited.Add(this);

        // ť�� ������� ������ �ݺ� (BFS Ž��)
        while (queue.Count > 0)
        {
            IChainable current = queue.Dequeue();

            // ���� ������Ʈ�� NearSynergy ����Ʈ�� ��ȸ�Ͽ� ������ ������Ʈ Ž��
            foreach (var neighbor in current.NearSynergy)
            {
                // neighbor�� ���� �湮���� �ʾҰ�, �ó��� Ÿ���� ������ ��쿡�� �߰�
                if (!visited.Contains(neighbor) && neighbor.SynergyType == this.SynergyType)
                {
                    // neighbor�� �湮�� ����Ʈ�� �߰��ϰ� ť�� ����
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        int synergyCount = visited.Count;

        // Ž���� ��� ������Ʈ�� ������ �ó��� ī��Ʈ�� ����
        foreach (var chainable in visited)
        {
            chainable.SynergyUpdate(synergyCount);
        }
    }

    // SynergyUpdate�� �߻� �޼���� �����Ͽ� �� Ŭ�������� �����ϵ��� ��
    public abstract void SynergyUpdate(int count);
       
}
