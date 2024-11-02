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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ���콺 ��ġ���� ���� ����

            if (Physics.Raycast(ray, out hit,10000, layerMask)) // �Ÿ� 10000�� �ӽ�. �ٸ� ���� �ٲ㵵 ������
            {
                // ���߿� ��� �߰� :���� ���콺�� ��ġ ������ �ٴ� ���� �ִ���
                // �Ƹ� �±�? �� �� ��
                isPlaceable = true;
                mousePos = hit.point;

                // ������Ʈ ���� �� �̸� ���
                Debug.Log("You can place the tower here.: " + hit.collider.name);
            }
        }
    }
}
