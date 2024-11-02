using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    public static MapInfo instance;

    public int cell_MaxX;
    public int cell_MaxY;
    public GameObject Map;
    public GameObject[,] mapMatrix;
    Vector3 cell_center;
    int cell_idx_x;
    int cell_idx_y;

    Vector3 mousePos;

    private LineRenderer lineRenderer;

    void Start()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);

        mapMatrix = new GameObject[cell_MaxY, cell_MaxX];
        Map.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(cell_MaxX / 2, cell_MaxY / 2);

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 5; // 사각형을 그리기 위해 5개 포인트 (마지막이 처음으로 돌아감)
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
        Vector3 cellScale = new Vector3(Map.transform.localScale.x / cell_MaxX * 10f, 0, Map.transform.localScale.y / cell_MaxY * 10f);

        Vector3 top_left = new Vector3((-Map.transform.localScale.x * 10f / 2f) + (cellScale.x / 2f),
            0, (Map.transform.localScale.y * 10f / 2f) - (cellScale.z / 2f));

        cell_idx_x = Mathf.FloorToInt(mousePos.x / 2 / cell_MaxX) + cell_MaxX / 2;
        cell_idx_y = Mathf.FloorToInt(mousePos.z / 2 / cell_MaxY) - cell_MaxY / 2 + 1; //카메라 깊이
        
        Vector3 offset = new Vector3(cell_idx_x * cellScale.x, 0, cell_idx_y * cellScale.z);
        cell_center = top_left + offset;

        // 사각형 꼭짓점 설정
        Vector3[] corners = new Vector3[5];
        corners[0] = top_left + offset + new Vector3(-cellScale.x / 2, 0, cellScale.z / 2);
        corners[1] = top_left + offset + new Vector3(cellScale.x / 2, 0, cellScale.z / 2);
        corners[2] = top_left + offset + new Vector3(cellScale.x / 2, 0, -cellScale.z / 2);
        corners[3] = top_left + offset + new Vector3(-cellScale.x / 2, 0, -cellScale.z / 2);
        corners[4] = corners[0]; // 마지막 점을 첫 번째 점으로 연결하여 사각형을 닫음

        lineRenderer.SetPositions(corners);
    }

    public void FixUnitPos(GameObject obj)
    {
        obj.transform.position = cell_center;
    }

    public bool PutUnit(GameObject obj)
    {
        if(mapMatrix[cell_idx_x, -cell_idx_y] == null)
        {
            mapMatrix[cell_idx_x, -cell_idx_y] = obj;
            return true;
        }
        else
        {
            return false;
        }
    }
}