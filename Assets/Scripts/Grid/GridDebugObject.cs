using TMPro;
using UnityEngine;

/// <summary>
/// Used for debugging purposes. Shows the grid position of the object.
/// Also shows if there is a unit on the grid position.
/// </summary>
public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private GameObject textMeshGameObject;
    GridObject gridObject;

    private void Update()
    {
        if (gridObject != null)
            textMeshGameObject.GetComponent<TextMeshPro>().text = gridObject.ToString();
    }

    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }
}
