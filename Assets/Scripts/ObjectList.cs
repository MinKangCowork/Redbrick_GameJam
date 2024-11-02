using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    public static ObjectList instance;

    public List<ObjectHandle> list = new List<ObjectHandle>();
    public int maxCount;
    RectTransform parentRect;
    public Vector2 offset;

    // 테스트용
    public ObjectHandle prefab_handle;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        parentRect = gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && list.Count < maxCount)
        {
            ObjectHandle test = Instantiate(prefab_handle, this.transform);
            AddList(test);
        }

        /*if(Input.GetMouseButtonUp(0))
        {
            if(InputController.instance.isPlaceable)
            {
                Debug.Log("TEST");
            }
        }*/
    }
    public void AddList(ObjectHandle obj)
    {
        // 리스트의 UI 좌표계
        RectTransform parentRect = this.gameObject.GetComponent<RectTransform>();
        RectTransform itemRect;

        try
        {
            // 등장한 아이템의 UI 좌표계
            //GameObject item = (GameObject)obj.unit;
            itemRect = obj.GetComponent<RectTransform>();
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

    public void RemoveList(ObjectHandle obj)
    {
        int idx = list.IndexOf(obj);
        {
            for(int i = idx;i<list.Count-1;i++)
            {
                Vector2 targetPos = list[i].GetComponent<RectTransform>().anchoredPosition;
                //if(list.Count == 1) break;
                list[i+1].GetComponent<RectTransform>().DOAnchorPosX(targetPos.x, 1f);
            }
        }
        list.Remove(obj);
    }
}
