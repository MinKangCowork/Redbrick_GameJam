using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController instance;

    public bool isPlaceable;
    public RaycastHit hit;
    Vector3 mousePos;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }

        if (Input.GetMouseButton(0))
        {
            int layerMask = LayerMask.GetMask("Ground");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 위치에서 레이 생성

            if (Physics.Raycast(ray, out hit,10000, layerMask)) // 거리 10000은 임시. 다른 수로 바꿔도 무방함
            {
                // 나중에 기능 추가 :현재 마우스가 배치 가능한 바닥 위에 있는지
                // 아마 태그? 로 할 듯
                isPlaceable = true;
                mousePos = hit.point;

                // 오브젝트 감지 시 이름 출력
                Debug.Log("You can place the tower here.: " + hit.collider.name);
            }
        }
    }
}
