using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{    
    [Header("# 공통 속성")]
    public int itemId;
    public string itemName;
    public Sprite itemIcon;    

    [TextArea]
    public string[] itemDesc;

    // 추상 메서드 선언
    //protected abstract void OnValidate();
}
