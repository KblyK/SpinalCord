using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private float x_Start = -6.3F, y_Start = 5.5F, z_Start = 3F, x_Space, y_Space, z_Space, height = 9F, width = 7.3F, depth = 3F;
    public GameObject prefab;
    private LineRenderer line;
    private List<GameObject> instantiatedList = new List<GameObject>();
    private Vector3[,,] arrayMap;

    public void Draw(Inputs inputs, BaseDots dots, TargetDots targetDots)
    {
        DestroyInstantiated();
        GenerateCoordinates(inputs);
        DrawLine(
            arrayMap[targetDots.x_Dot1, targetDots.y_Dot1, targetDots.z_Dot1],
            arrayMap[dots.x_Dot1, dots.y_Dot1, dots.z_Dot1]);
        //DrawLine2(new Vector3(targetDots.x_Dot1, targetDots.y_Dot1, targetDots.z_Dot1));
        //DrawLine(arrayMap[6, 4, 1], arrayMap[3, 4, 1]);
        //DrawLine2(arrayMap[3, 4, 1], arrayMap[8, 2, 1]);
    }

    void GenerateCoordinates(Inputs inputs)
    {
        x_Space = (float)(width) / (float)inputs.Width;
        y_Space = (float)(height) / (float)inputs.Height;
        z_Space = (float)(depth) / (float)inputs.Depth;

        line = GetComponent<LineRenderer>();
        line.positionCount = 8;
        arrayMap = new Vector3[inputs.Width, inputs.Height, inputs.Depth];

        for (int depth = 0; depth < inputs.Depth; depth++)
        {
            for (int row = 0; row < inputs.Width; row++)
            {
                for (int col = 0; col < inputs.Height; col++)
                {
                    Vector3 dot = new Vector3(x_Start + (x_Space * row), y_Start + (-y_Space * col), z_Start + (z_Space * depth));
                    arrayMap[row, col, depth] = dot;

                    GameObject instantiatedObj = Instantiate(prefab, dot, Quaternion.identity);
                    instantiatedList.Add(instantiatedObj);
                }
            }
        }
    }

    void DestroyInstantiated()
    {
        while (instantiatedList.Count > 0)
        {
            for (int instantiated = 0; instantiated < instantiatedList.Count; instantiated++)
            {
                Destroy(instantiatedList[instantiated]);
                instantiatedList.Remove(instantiatedList[instantiated]);
            }
        }
    }

    void DrawLine(Vector3 source, Vector3 middle)
    {
        line.SetPosition(0, source);
        Debug.Log($"{source.x} - {source.y} - {source.z}");
        line.SetPosition(1, middle);
        Debug.Log($"{middle.x} - {middle.y} - {middle.z}");
    }

    void DrawLine2(Vector3 source)
    {
        line.SetPosition(2, source);
        Debug.Log($"{source.x} - {source.y} - {source.z}");
        source.x = -source.x;
        line.SetPosition(3, source);
        Debug.Log($"{source.x} - {source.y} - {source.z}");
    }
}