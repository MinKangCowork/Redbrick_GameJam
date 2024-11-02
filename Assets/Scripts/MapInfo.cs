using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    public static MapInfo instance;

    public int cell_x;
    public int cell_y;
    public GameObject Map;
    public GameObject[,] mapMatrix;
    Vector3 cell_center;

    Vector3 mousePos;

    private LineRenderer lineRenderer;

    void Start()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);

        mapMatrix = new GameObject[cell_y, cell_x];

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 5; // �簢���� �׸��� ���� 5�� ����Ʈ (�������� ó������ ���ư�)
        lineRenderer.loop = true;
        lineRenderer.useWorldSpace = true;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = InputController.instance.hit.point;
        DrawGrid();
    }

    private void DrawGrid()
    {
        Vector3 cellScale = new Vector3(Map.transform.localScale.x / cell_x * 10f, 0, Map.transform.localScale.y / cell_y * 10f);

        Vector3 top_left = new Vector3((-Map.transform.localScale.x * 10f / 2f) + (cellScale.x / 2f),
            0, (Map.transform.localScale.y * 10f / 2f) - (cellScale.z / 2f));

        int x = Mathf.FloorToInt(mousePos.x / 2 / cell_x) + cell_x / 2;
        int y = Mathf.FloorToInt(mousePos.z / 2 / cell_y) - cell_y / 2 + 1; //ī�޶� ����
        Vector3 offset = new Vector3(x * cellScale.x, 0, y * cellScale.z);
        cell_center = top_left + offset;

        // �簢�� ������ ����
        Vector3[] corners = new Vector3[5];
        corners[0] = top_left + offset + new Vector3(-cellScale.x / 2, 0, cellScale.z / 2);
        corners[1] = top_left + offset + new Vector3(cellScale.x / 2, 0, cellScale.z / 2);
        corners[2] = top_left + offset + new Vector3(cellScale.x / 2, 0, -cellScale.z / 2);
        corners[3] = top_left + offset + new Vector3(-cellScale.x / 2, 0, -cellScale.z / 2);
        corners[4] = corners[0]; // ������ ���� ù ��° ������ �����Ͽ� �簢���� ����

        lineRenderer.SetPositions(corners);
    }

    public void FixUnitPos(GameObject obj)
    {
        obj.transform.position = cell_center;
    }
}