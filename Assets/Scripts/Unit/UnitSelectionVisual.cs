using UnityEngine;

public class UnitSelectionVisual : MonoBehaviour
{
    [SerializeField] private GameObject unitSelectionVisual;
    private Unit unit;

    private void Awake()
    {
        unitSelectionVisual.SetActive(false);
        unit = GetComponent<Unit>();
    }

    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
    }

    void UnitActionSystem_OnSelectedUnitChanged(object sender, System.EventArgs e)
    {
        if (((UnitActionSystem)sender).GetSelectedUnit() == unit)
        {
            unitSelectionVisual.SetActive(true);
        }
        else
        {
            unitSelectionVisual.SetActive(false);
        }
    }
}
