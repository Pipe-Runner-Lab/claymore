using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
