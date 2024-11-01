using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController instance;

    public bool isPlaceable;
    public RaycastHit hit;

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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 위치에서 레이 생성

            if (Physics.Raycast(ray, out hit))
            {
                // 나중에 기능 추가 :현재 마우스가 배치 가능한 바닥 위에 있는지
                // 아마 태그? 로 할 듯
                isPlaceable = true;

                // 오브젝트 감지 시 이름 출력
                Debug.Log("You can place the tower here.: " + hit.collider.name);
            }
        }
    }
}
