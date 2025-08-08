using System;
using UnityEngine;

namespace CodeBase
{
    public class CellBuildingLogic : MonoBehaviour
    {
        public Action OnCellAim;
        public Action OnCellAimCancel;
        public Action OnCellSelect;
        
        public Cell cell;
        private BuildingSpawner buildingSpawner;
        public Vector3 offset;
        
        private void Awake()
        {
            buildingSpawner = FindObjectOfType<BuildingSpawner>();
        }

        private void OnMouseDown()
        {
            OnCellSelect?.Invoke();
            buildingSpawner.PlaceBuilding(cell.GetCellPosition() + offset,cell.isEmpty);
            cell.FillInCell();
        }
    
        private void OnMouseEnter()
        {
            OnCellAim?.Invoke();
            buildingSpawner.DestroyGhostBuilding(cell.isEmpty);
            buildingSpawner.MoveGhostTo(cell.GetCellPosition() + offset,cell.isEmpty);
        }

        private void OnMouseExit()
        {
            OnCellAimCancel?.Invoke();
            //buildingSpawner.HideGhostBuilding();
        }
        
    }
}