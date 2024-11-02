using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    public int cell_x;
    public int cell_y;
    public GameObject Map;

    public GameObject[,] mapMatrix;
    void Start()
    {
        mapMatrix = new GameObject[cell_y, cell_x];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Vector3 cellScale = new Vector3(Map.transform.localScale.x / cell_x * 10f, Map.transform.localScale.y / cell_y * 10f, 0);
        Debug.Log(cellScale);

        Vector3 top_left = new Vector3((-Map.transform.localScale.x * 10f / 2f) + (cellScale.x / 2f),
            (Map.transform.localScale.y * 10f / 2f) - (cellScale.y / 2f), 0);
        Debug.Log(top_left);

        Gizmos.DrawWireCube(top_left, cellScale);
        //Gizmos.DrawLine
    }
}