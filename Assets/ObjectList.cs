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

    // 테스트용
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
        // 리스트의 UI 좌표계
        RectTransform parentRect = this.gameObject.GetComponent<RectTransform>();
        RectTransform itemRect;

        try
        {
            // 등장한 아이템의 UI 좌표계
            GameObject item = (GameObject)obj;
            itemRect = item.GetComponent<RectTransform>();
        }
        catch
        {
            Debug.LogError("Can't add this Item");
            return;
        }

        // 리스트에 추가하면 이미지가 여기서 출발
        Vector2 enterPos = new Vector2((parentRect.rect.width / 2) - (itemRect.rect.width / 2), 0);
        itemRect.anchoredPosition = enterPos;

        // 쌓여있는 리스트의 뒤에 이미지 도착
        Vector2 targetPos = new Vector2(-(parentRect.rect.width / 2) + (itemRect.rect.width / 2) + offset.x + ((itemRect.rect.width + offset.x) * list.Count), 0);
        itemRect.DOAnchorPosX(targetPos.x, 1f);

        list.Add(obj);
    }
}
