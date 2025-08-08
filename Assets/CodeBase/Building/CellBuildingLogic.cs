using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase
{
    public class CellBuildingLogic : MonoBehaviour
    {
        public Action OnCellAim;
        public Action OnCellAimCancel;
        public Action OnCellSelect;
        List<GameObject> cellsList = new List<GameObject>();
        public Cell cell;
        private BuildingSpawner buildingSpawner;
        private GameFieldGenerator gameFieldGenerator;
        private GameFieldBehaviourAdjuster gameFieldBehaviourAdjuster;
        private bool canBuildHere;
        public Vector3 offset;
        
        private void Awake()
        {
            buildingSpawner = FindObjectOfType<BuildingSpawner>();
            gameFieldGenerator = FindObjectOfType<GameFieldGenerator>();
            gameFieldBehaviourAdjuster = new GameFieldBehaviourAdjuster();

        }
        
        private void OnMouseEnter()
        {
            OnCellAim?.Invoke();
           canBuildHere = gameFieldBehaviourAdjuster.BuildingCellsAdjusting
                (gameFieldGenerator.GetCells(),buildingSpawner.GetCellsCountToBuild(),cellsList,cell,gameFieldGenerator.GetFieldWidth());
            
            buildingSpawner.DestroyGhostBuilding(canBuildHere);
            buildingSpawner.MoveGhostTo(cell.GetCellPosition() + offset,canBuildHere);
            
        }

        private void OnMouseExit()
        {
            OnCellAimCancel?.Invoke();
            RemoveCells();
            
        }

        private void OnMouseDown()
        {
            OnCellSelect?.Invoke();
            buildingSpawner.PlaceBuilding(cell.GetCellPosition() + offset,canBuildHere);
            foreach (var cell in cellsList)
            {
                var gamecell = cell.GetComponent<Cell>();
                gamecell.FillInCell();
                Debug.LogError($"Cell id: {gamecell.cellId }, empty status : {gamecell.isEmpty}");
            }
            
        }

        private void RemoveCells()
        {
            Debug.LogError($"Cells count : {cellsList.Count}");
            int i = 0;
            if (cellsList.Count > 0)
            {
             while (i < buildingSpawner.GetCellsCountToBuild())
             {
                 cellsList[0].GetComponent<CellOutliner>().CancelOutline();
                 cellsList.RemoveAt(0);
                 i++;
             }
            }
        }
        
    }
}