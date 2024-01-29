using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class responsible for creating and managing the grid when the game starts.
/// Singleton pattern is used to ensure that there is only one instance of this class.
/// </summary>
public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }
    [SerializeField] private GameObject debugPrefab;
    private GridSystem gridSystem;

    private void Awake()
    {
        Instance = this;
        gridSystem = new GridSystem(10, 10);
        gridSystem.CreateDebugObjects(debugPrefab);
    }

    public void AddUnitAtGridObject(Unit unit, GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitsAtGridObject(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnits();
    }

    public void RemoveUnitAtGridObject(Unit unit, GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void MoveUnitFromTo(Unit unit, GridPosition from, GridPosition to)
    {
        RemoveUnitAtGridObject(unit, from);
        AddUnitAtGridObject(unit, to);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);

    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);

    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);

    public bool HasAnyUnitAtGridPosition(GridPosition gridPosition) => Instance.GetUnitsAtGridObject(gridPosition).Count > 0;

    public int GetHeight() => gridSystem.height;
    public int GetWidth() => gridSystem.width;
}
