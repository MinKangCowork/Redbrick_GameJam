using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEngine.UI.CanvasScaler;

public class ObjectHandle : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    Image icon;
    public Object unit;
    public bool isDragging;
    public List<GameObject> templet;

    public void Init()
    {
        unit = GameManager.Instance.pool.Get(PoolManager.PoolType.Tower, 0);
    }

    void Start()
    {
        Init();
        icon = GetComponent<Image>();
    }

    void Update()
    {
        /*if (isDragging)
        {
            icon.color = new Color(1, 1, 1, 0);
        }
        else
        {
            icon.color = new Color(1, 1, 1, 1);
        }*/
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (InputController.instance.isPlaceable)
        {
            GameObject unit_g = (GameObject)unit;
            unit_g.layer = 2;
            unit_g.transform.position = InputController.instance.hit.point;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(InputController.instance.isPlaceable)
        {
            ObjectList.instance.RemoveList(this);
            icon.color = new Color(1, 1, 1, 0);


            ActiveUnit();
            //unit.
        }
        else isDragging = false;
    }

    public void ActiveUnit()
    {
        // 유닛 배치했을 때 실행
        unit.GetComponent<IFireBullet>().FireStart();
    }
}
