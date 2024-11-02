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
        NearSynergy = new List<IChainable> { this }; // 자기 자신을 초기 리스트에 추가
    }

    
    public void ChainEnterCheck(IChainable oChain)
    {
        if (this.SynergyType == oChain.SynergyType && !NearSynergy.Contains(oChain))
        {
            NearSynergy.Add(oChain);
            oChain.NearSynergy.Add(this); // 상대방의 리스트에도 자신을 추가
            UpdateSynergyForGroup(); // 시너지 그룹 업데이트
        }
    }

    public void ChainExitCheck(IChainable oChain)
    {
        if (this.SynergyType == oChain.SynergyType && NearSynergy.Contains(oChain))
        {
            NearSynergy.Remove(oChain);
            oChain.NearSynergy.Remove(this); // 상대방의 리스트에서도 자신을 제거
            UpdateSynergyForGroup(); // 시너지 그룹 업데이트            
        }
    }

    // 시너지 그룹 전체를 업데이트하는 메서드
    public void UpdateSynergyForGroup()
    {
        HashSet<IChainable> visited = new HashSet<IChainable>();
        Queue<IChainable> queue = new Queue<IChainable>();

        queue.Enqueue(this);
        visited.Add(this);

        // 큐가 비어있을 때까지 반복 (BFS 탐색)
        while (queue.Count > 0)
        {
            IChainable current = queue.Dequeue();

            // 현재 오브젝트의 NearSynergy 리스트를 순회하여 인접한 오브젝트 탐색
            foreach (var neighbor in current.NearSynergy)
            {
                // neighbor가 아직 방문되지 않았고, 시너지 타입이 동일한 경우에만 추가
                if (!visited.Contains(neighbor) && neighbor.SynergyType == this.SynergyType)
                {
                    // neighbor를 방문한 리스트에 추가하고 큐에 넣음
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        int synergyCount = visited.Count;

        // 탐색된 모든 오브젝트에 동일한 시너지 카운트를 적용
        foreach (var chainable in visited)
        {
            chainable.SynergyUpdate(synergyCount);
        }
    }

    // SynergyUpdate는 추상 메서드로 선언하여 각 클래스에서 구현하도록 함
    public abstract void SynergyUpdate(int count);
       
}
