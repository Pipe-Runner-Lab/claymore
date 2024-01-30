using UnityEngine;

public class Unit : MonoBehaviour
{
    private GridPosition currentGridPosition;
    private MoveAction moveAction;

    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
    }

    private void Start()
    {
        LevelGrid.Instance.AddUnitAtGridObject(this, LevelGrid.Instance.GetGridPosition(transform.position));
        currentGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if (newGridPosition != currentGridPosition)
        {
            Debug.Log("Unit moved from " + currentGridPosition + " to " + newGridPosition);
            LevelGrid.Instance.MoveUnitFromTo(this, currentGridPosition, newGridPosition);
            currentGridPosition = newGridPosition;
        }
    }

    public MoveAction GetMoveAction()
    {
        return moveAction;
    }

    public GridPosition GetCurrentGridPosition()
    {
        return currentGridPosition;
    }
}
