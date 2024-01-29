using UnityEngine;

/// <summary>
/// A class that represents an entire grid - consists of many grid objects.
/// </summary>
public class GridSystem
{
    public int width { get; private set; }
    public int height { get; private set; }
    public float cellSize { get; private set; } = 2f;

    private GridObject[,] gridObjects;

    public GridSystem(int width, int height, float cellSize = 2f)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjects = new GridObject[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                // for testing
                // Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j) + Vector3.right * 0.2f, Color.white);
                gridObjects[i, j] = new GridObject(this, new GridPosition(i, j));
            }
        }
    }

    /// <summary>
    /// Converts a grid position to a world position.
    /// </summary>
    /// <param name="gridPosition"></param>
    /// <returns></returns>
    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    /// <summary>
    /// Converts a world position to a grid position.
    /// </summary>
    /// <param name="WorldPosition"></param>
    /// <returns></returns>
    public GridPosition GetGridPosition(Vector3 WorldPosition)
    {
        return new GridPosition(Mathf.FloorToInt(WorldPosition.x / cellSize), Mathf.RoundToInt(WorldPosition.z / cellSize));
    }

    public void CreateDebugObjects(GameObject debugPrefab)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GridPosition gridPosition = new(i, j);
                GameObject gridDebugGameObject = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity);
                gridDebugGameObject.GetComponent<GridDebugObject>().SetGridObject(
                    GetGridObject(gridPosition)
                );
            }
        }
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjects[gridPosition.x, gridPosition.z];
    }

    public bool IsValidGridPosition(GridPosition gridPosition)
    {
        return gridPosition.x >= 0 && gridPosition.x < width && gridPosition.z >= 0 && gridPosition.z < height;
    }
}
