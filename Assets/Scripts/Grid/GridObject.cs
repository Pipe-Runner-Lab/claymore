using System.Collections.Generic;

public class GridObject
{
  private readonly GridSystem gridSystem;
  private readonly GridPosition gridPosition;

  private readonly List<Unit> Units;

  public GridObject(GridSystem gridSystem, GridPosition gridPosition)
  {
    this.gridSystem = gridSystem;
    this.gridPosition = gridPosition;

    Units = new List<Unit>();
  }

  public void AddUnit(Unit unit)
  {
    Units.Add(unit);
  }

  public void RemoveUnit(Unit unit)
  {
    Units.Remove(unit);
  }

  public List<Unit> GetUnits()
  {
    return Units;
  }

  public override string ToString()
  {
    if (Units.Count == 0)
      return gridPosition.ToString();
    else
      return gridPosition.ToString() + $" unit";
  }
}