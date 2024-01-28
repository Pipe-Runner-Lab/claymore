using System;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    // Singleton pattern (set is private so that properties cannot be changed from outside)
    public static UnitActionSystem Instance { get; private set; }

    public event EventHandler OnSelectedUnitChanged;

    [SerializeField] private Unit unit;
    [SerializeField] private LayerMask unitLayerMask;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one unit action system in the scene! " + transform + " - " + Instance);
            Destroy(gameObject); // destroy this game object if there is already an instance
            return;
        }
        Instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (HandleUnitSelection()) return;
            if (unit) unit.GetMoveAction().Move(MouseWorld.GetMousePosition());
        }
    }

    bool HandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, unitLayerMask))
        {
            // we can also use the transform component of the object
            if (hitInfo.collider.TryGetComponent(out Unit unit))
            {
                SelectUnit(unit);
            }

            return true;
        }

        return false;
    }

    private void SelectUnit(Unit unit)
    {
        this.unit = unit;

        // syntactic sugar for if (OnSelectedUnitChanged != null) OnSelectedUnitChanged(this, EventArgs.Empty);
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit()
    {
        return unit;
    }
}
