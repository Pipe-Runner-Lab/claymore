using System.Collections.Generic;
using UnityEngine;

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
}
