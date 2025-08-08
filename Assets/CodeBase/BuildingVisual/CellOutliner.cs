using CodeBase;
using UnityEngine;
public class CellOutliner : MonoBehaviour
{
    [SerializeField] private CellBuildingLogic cellBuildingLogic;
    private Material originalMaterial;
    private Color originalColor;
    private SelectColor _selectColor;
    
    private void Start()
    {
        _selectColor = FindObjectOfType<SelectColor>();
        originalMaterial = GetComponent<Renderer>().material;
        originalColor = originalMaterial.color;
        cellBuildingLogic.OnCellAim += StartOutline;
        cellBuildingLogic.OnCellAimCancel += CancelOutline;
    }

    private void OnDestroy()
    {
        cellBuildingLogic.OnCellAim -= StartOutline;
        cellBuildingLogic.OnCellAimCancel -= CancelOutline;
    }

    private void StartOutline()
    {
        originalMaterial.color =  _selectColor.color;
    }

    private void CancelOutline()
    {
        originalMaterial.color = originalColor;
    }

}