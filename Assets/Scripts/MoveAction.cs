using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    const float DISTANCE_THRESHOLD = 0.1f;

    [SerializeField] private int MAX_MOVE_DISTANCE = 4;
    [SerializeField] private Animator unitAnimator;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 7f;

    private Vector3 targetPosition;
    private Unit unit;

    private void Awake()
    {
        targetPosition = transform.position;
        unit = GetComponent<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(targetPosition, transform.position) > DISTANCE_THRESHOLD)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += movementSpeed * Time.deltaTime * moveDirection;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotationSpeed * Time.deltaTime);
            unitAnimator.SetBool("IsWalking", true);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }
    }

    public void Move(Vector3 position)
    {
        targetPosition = position;
    }

    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validActionGridPositionList = new();
        GridPosition currentGridPosition = unit.GetCurrentGridPosition();

        for (int x = -MAX_MOVE_DISTANCE; x <= MAX_MOVE_DISTANCE; x++)
        {
            for (int z = -MAX_MOVE_DISTANCE; z <= MAX_MOVE_DISTANCE; z++)
            {
                GridPosition testPosition = currentGridPosition + new GridPosition(x, z);
                // if (LevelGrid.Instance.IsGridPositionWithinBounds(gridPosition))
                // {
                //     validActionGridPositionList.Add(gridPosition);
                // }
            }
        }

        return validActionGridPositionList;
    }
}
