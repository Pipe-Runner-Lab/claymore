using System.Collections;
using System.Collections.Generic;
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

    public static Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, Instance.mouseLayerMask);
        if (Instance.shouldRenderMousePointer)
        {
            if (hitInfo.collider == null)
            {
                Instance.mousePointer.SetActive(false);
            }
            else
            {
                Instance.mousePointer.SetActive(true);
                Instance.mousePointer.transform.position = hitInfo.point;
            }
        }

        return hitInfo.point;
    }
}
