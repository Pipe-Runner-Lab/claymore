using UnityEngine;

public class GridVisual : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    public void Hide()
    {
        meshRenderer.enabled = false;
    }

    public void Show()
    {
        meshRenderer.enabled = true;
    }
}
