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
    }
    public void StartOutline(bool cellStatus)
    {
        if(!cellStatus)
        originalMaterial.color =  _selectColor.emptyCellColor;
        else originalMaterial.color =  _selectColor.notEmptyCellColor;
    }

    public void CancelOutline()
    {
        originalMaterial.color = originalColor;
    }

}