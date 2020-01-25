using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    float x_Start = -6.3F, y_Start = 5.5F, z_Start = 3F;
    float x_Space, y_Space, z_Space;
    public GameObject prefab;
    private Vector3[, ,] arrayMap;
    private LineRenderer line;
    private float height = 9F;
    private float width = 7.3F;
    private float depth = 3F;

    public void Draw(int columnLength, int rowLength, int depthLength)
    {
        x_Space = (float)(width) / (float)rowLength;
        y_Space = (float)(height) / (float)columnLength;
        z_Space = (float)(depth) / (float)depthLength;

        line = GetComponent<LineRenderer>();
        arrayMap = new Vector3[rowLength, columnLength, depthLength];

        for (int depth = 0; depth < depthLength; depth++)
        {
            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < columnLength; col++)
                {
                    Vector3 dot = new Vector3(x_Start + (x_Space * row), y_Start + (-y_Space * col), z_Start + (z_Space * depth));
                    arrayMap[row, col, depth] = dot;//col + 1;
                    Instantiate(prefab, dot, Quaternion.identity);
                }
            }
        }
        DrawLine(arrayMap[6, 4, 1], arrayMap[3, 4, 1], arrayMap[6, 8, 1]);
        DrawLine2(arrayMap[3, 4, 1], arrayMap[8, 2, 1]);
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