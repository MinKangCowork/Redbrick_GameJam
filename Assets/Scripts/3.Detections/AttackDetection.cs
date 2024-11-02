using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetection : MonoBehaviour
{
    private IAttackable baseAttackable;

    private void Awake()
    {
        baseAttackable =  GetComponentInParent<IAttackable>();
    }
    private void OnTriggerStay(Collider other)
    {
        IAttackable oDetect = other.GetComponent<IAttackable>();
        if (oDetect != null)
        {
            baseAttackable.IsDetection = true;
        }
        else
            baseAttackable.IsDetection = false;
    }

    private void OnTriggerExit(Collider other)
    {
        IAttackable oDetect = other.GetComponent<IAttackable>();
        if (oDetect != null)
        {
            baseAttackable.IsDetection = false;
        }
    }
}
