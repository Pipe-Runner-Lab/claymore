using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public static MouseWorld Instance;

    [SerializeField] private GameObject mousePointer;
    [SerializeField] private LayerMask mouseLayerMask;
    [SerializeField] private bool shouldRenderMousePointer = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Instance.shouldRenderMousePointer)
        {
            Instance.mousePointer.SetActive(true);
            GetMousePosition();
        }
        else
        {
            Instance.mousePointer.SetActive(false);
        }
    }

    public static Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, Instance.mouseLayerMask);


        if (hitInfo.collider)
            Instance.mousePointer.transform.position = hitInfo.point;

        return hitInfo.point;
    }
}
