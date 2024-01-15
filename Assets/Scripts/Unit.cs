using UnityEngine;

public class Unit : MonoBehaviour
{
    const float DISTANCE_THRESHOLD = 0.1f;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 7f;
    [SerializeField] private Animator unitAnimator;

    private Vector3 targetPosition;

    private GridPosition currentGridPosition;

    public void Move(Vector3 position)
    {
        targetPosition = position;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Start()
    {
        LevelGrid.Instance.AddUnitAtGridObject(this, LevelGrid.Instance.GetGridPosition(transform.position));
        currentGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(targetPosition, transform.position) > DISTANCE_THRESHOLD)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += movementSpeed * Time.deltaTime * moveDirection;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotationSpeed * Time.deltaTime);
            unitAnimator.SetBool("IsWalking", true);

            GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            if (newGridPosition != currentGridPosition)
            {
                LevelGrid.Instance.MoveUnitFromTo(this, currentGridPosition, newGridPosition);
                currentGridPosition = newGridPosition;
            }
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }
    }
}
