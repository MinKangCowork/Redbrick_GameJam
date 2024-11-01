using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface ITriggerHandler 
{    
    void OnChildTriggerEnter(Collider other);
    void OnChildTriggerExit(Collider other);
}
