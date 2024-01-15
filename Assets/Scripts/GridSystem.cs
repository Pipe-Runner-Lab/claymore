using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    public int width;
    public int height;
    float cellSize = 2f;

    public GridSystem(int width, int height, float cellSize = 2f)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                // for testing
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j) + Vector3.right * 0.2f, Color.white, 100f);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, 0, y) * cellSize;
    }
}
