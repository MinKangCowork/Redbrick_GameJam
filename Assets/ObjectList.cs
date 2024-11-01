using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{

    List<Object> list = new List<Object>();
    public int maxCount;
    RectTransform parentRect;
    public Vector2 offset;

    // �׽�Ʈ��
    public GameObject abc;

    private void Start()
    {
        parentRect = gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && list.Count < maxCount)
        {
            GameObject test = Instantiate(abc,this.transform);
            AddList(test);
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(InputController.instance.isPlaceable)
            {
                Debug.Log("TEST");
            }
        }
    }
    public void AddList(Object obj)
    {
        // ����Ʈ�� UI ��ǥ��
        RectTransform parentRect = this.gameObject.GetComponent<RectTransform>();
        RectTransform itemRect;

        try
        {
            // ������ �������� UI ��ǥ��
            GameObject item = (GameObject)obj;
            itemRect = item.GetComponent<RectTransform>();
        }
        catch
        {
            Debug.LogError("Can't add this Item");
            return;
        }

        // ����Ʈ�� �߰��ϸ� �̹����� ���⼭ ���
        Vector2 enterPos = new Vector2((parentRect.rect.width / 2) - (itemRect.rect.width / 2), 0);
        itemRect.anchoredPosition = enterPos;

        // �׿��ִ� ����Ʈ�� �ڿ� �̹��� ����
        Vector2 targetPos = new Vector2(-(parentRect.rect.width / 2) + (itemRect.rect.width / 2) + offset.x + ((itemRect.rect.width + offset.x) * list.Count), 0);
        itemRect.DOAnchorPosX(targetPos.x, 1f);

        list.Add(obj);
    }
}
