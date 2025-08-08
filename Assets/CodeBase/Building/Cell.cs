using UnityEngine;
public class Cell : MonoBehaviour
{
     public bool isEmpty;

     public Vector2Int cellId;

    public void FillInCell() => isEmpty = true; 
    
    public Vector3 GetCellPosition() => this.gameObject.transform.position;
    
    public void ClearCell() => isEmpty = false;

}
