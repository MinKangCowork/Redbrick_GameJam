using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseTower : MonoBehaviour, IUnitInfo
{  
    [field: SerializeField]
    public int Id { get; set; }

    [field: SerializeField]
    public float attackDelay;     
}
