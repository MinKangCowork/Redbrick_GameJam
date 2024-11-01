using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{    
    [Header("# ���� �Ӽ�")]
    public int itemId;
    public string itemName;
    public Sprite itemIcon;    

    [TextArea]
    public string[] itemDesc;

    // �߻� �޼��� ����
    //protected abstract void OnValidate();
}
