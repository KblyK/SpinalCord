using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    float x_Start = -6.3F, y_Start = 5.7F;
    int columnLength, rowLength;
    float x_Space = 0.5F, y_Space = 0.5F;
    public GameObject prefab;
    private Vector3[,] arrayMap;
    private LineRenderer line;

    public void Draw(int ColumnLength, int RowLenght)
    {
        columnLength = ColumnLength;
        rowLength = RowLenght;

        line = GetComponent<LineRenderer>();
        arrayMap = new Vector3[rowLength, columnLength];

        for (int row = 0; row < rowLength; row++)
        {
            for (int col = 0; col < columnLength; col++)
            {
                Vector3 dot = new Vector3(x_Start + (x_Space * row), y_Start + (-y_Space * col));
                arrayMap[row, col] = dot;//col + 1;
                Instantiate(prefab, dot, Quaternion.identity);
            }
        }
        DrawLine(arrayMap[6, 4], arrayMap[3, 4], arrayMap[6, 8]);
        DrawLine2(arrayMap[3, 4], arrayMap[8, 2]);
    }

    void DrawLine(Vector3 source, Vector3 middle, Vector3 destination)
    {
        line.positionCount = 5;
        line.SetPosition(0, source);
        line.SetPosition(1, middle);
        line.SetPosition(2, destination);
    }

    void DrawLine2(Vector3 source, Vector3 destination)
    {
        line.SetPosition(3, source);
        line.SetPosition(4, destination);
    }
}