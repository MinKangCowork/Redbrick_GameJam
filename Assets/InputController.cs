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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ���콺 ��ġ���� ���� ����

            if (Physics.Raycast(ray, out hit))
            {
                // ���߿� ��� �߰� :���� ���콺�� ��ġ ������ �ٴ� ���� �ִ���
                // �Ƹ� �±�? �� �� ��
                isPlaceable = true;

                // ������Ʈ ���� �� �̸� ���
                Debug.Log("You can place the tower here.: " + hit.collider.name);
            }
        }
    }
}
