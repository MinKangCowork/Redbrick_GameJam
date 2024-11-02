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

        mapMatrix = new GameObject[cell_MaxX, cell_MaxY];
        Map.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2((float)cell_MaxX / 2f, (float)cell_MaxY / 2f);

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
        Vector3 cellScale = new Vector3(Map.transform.localScale.x * 10f / cell_MaxX , 0, Map.transform.localScale.y * 10f / cell_MaxY );

        Vector3 top_left = new Vector3((-Map.transform.localScale.x * 10f / 2f) + (cellScale.x / 2f),
            0, (Map.transform.localScale.y * 10f / 2f) - (cellScale.z / 2f));
        Debug.DrawRay(top_left, Vector3.up);

        cell_idx_x = Mathf.FloorToInt((mousePos.x - top_left.x + cellScale.x / 2) / cellScale.x);
        cell_idx_y = Mathf.FloorToInt((mousePos.z - top_left.z + cellScale.z / 2) / cellScale.z); //카메라 깊이

        Vector3 offset = new Vector3(cell_idx_x * cellScale.x, 0, cell_idx_y * cellScale.z);
        cell_center = top_left + offset;
        //Debug.Log(offset);
        Debug.DrawRay(cell_center, Vector3.up);

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
        Debug.Log($"{cell_idx_x}, {-cell_idx_y}");
        if (mapMatrix[cell_idx_x, -cell_idx_y] == null)
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