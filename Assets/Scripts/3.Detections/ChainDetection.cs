using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainDetection : MonoBehaviour
{
    public IChainable baseChainable;

    private void Awake()
    {
        baseChainable = GetComponentInParent<IChainable>();
        if (baseChainable == null)
        {
            Debug.LogError("IChainable �������̽��� �θ𿡼� ã�� �� �����ϴ�.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IChainable oChain = other.GetComponent<IChainable>();
        if (oChain != null)
        {
            baseChainable.ChainEnterCheck(oChain);            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IChainable oChain = other.GetComponent<IChainable>();
        if (oChain != null)
        {
            baseChainable.ChainExitCheck(oChain);
        }
    }
}
