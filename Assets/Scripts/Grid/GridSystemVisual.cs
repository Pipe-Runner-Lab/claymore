using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    [SerializeField] GameObject gridVisualPrefab;

    private GridVisual[,] gridVisualArray;

    // Start is called before the first frame update
    void Start()
    {
        gridVisualArray = new GridVisual[
            LevelGrid.Instance.GetWidth(),
            LevelGrid.Instance.GetHeight()
        ];

        for (int i = 0; i < LevelGrid.Instance.GetWidth(); i++)
        {
            for (int j = 0; j < LevelGrid.Instance.GetHeight(); j++)
            {
                GridPosition gridPosition = new(i, j);

                gridVisualArray[i, j] = Instantiate(
                    gridVisualPrefab,
                    LevelGrid.Instance.GetWorldPosition(gridPosition),
                    Quaternion.identity
                ).GetComponent<GridVisual>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == null)
        {
            Hide();
        }
        else
        {
            Show(
                UnitActionSystem.Instance.GetSelectedUnit().GetMoveAction().GetValidActionGridPositionList()
            );
        }
    }

    private void Hide()
    {
        for (int i = 0; i < LevelGrid.Instance.GetWidth(); i++)
        {
            for (int j = 0; j < LevelGrid.Instance.GetHeight(); j++)
            {
                gridVisualArray[i, j].Hide();
            }
        }
    }

    private void Show(List<GridPosition> gridPositions)
    {
        Hide();

        foreach (GridPosition gridPosition in gridPositions)
        {
            gridVisualArray[gridPosition.x, gridPosition.z].Show();
        }
    }
}
