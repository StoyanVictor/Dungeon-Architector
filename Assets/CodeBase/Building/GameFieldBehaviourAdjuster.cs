using System.Collections.Generic;
using UnityEngine;

public class GameFieldBehaviourAdjuster
{
    public bool BuildingCellsAdjusting(Dictionary<Vector2Int, Cell> cells,int cellsToBuild,List<GameObject> cellsList,Cell cellObject,int width)
    {
        switch (cellsToBuild)
        {
            case 1:
                cellsList.Add(cells[new Vector2Int(cellObject.cellId.x,cellObject.cellId.y)].transform.gameObject);
                OutlineAllCells(cellsList, CheckForEmptyness(cellsList));
                return CheckForEmptyness(cellsList);
                break;
            case 2:
                TwoCellsSpawn(cells, cellsList, cellObject, width);
                OutlineAllCells(cellsList, CheckForEmptyness(cellsList));
               return CheckForEmptyness(cellsList);
                break;
            case 3:
                ThreeCellsSpawn(cells, cellsList, cellObject, width);
                OutlineAllCells(cellsList, CheckForEmptyness(cellsList));
                return CheckForEmptyness(cellsList);
                break;
            default:
                Debug.Log("Not sigma :(");
                return false;
                break;
        }
        
        return false;
    }
    private void TwoCellsSpawn(Dictionary<Vector2Int, Cell> cells, List<GameObject> cellsList, Cell cellObject,int width)
    {
        bool isInFieldRageByX = cellObject.cellId.x + 1 < width;
        if (isInFieldRageByX)
        {
            cellsList.Add(cells[new Vector2Int(cellObject.cellId.x,cellObject.cellId.y)].transform.gameObject);
            cellsList.Add(cells[new Vector2Int(cellObject.cellId.x+1,cellObject.cellId.y)].transform.gameObject);
        }
        else
        {
            return;
        }

    }
    private void ThreeCellsSpawn(Dictionary<Vector2Int, Cell> cells, List<GameObject> cellsList, Cell cellObject,int width)
    {
        bool isInFieldRageByX = cellObject.cellId.x + 1 < width && cellObject.cellId.x - 1 > 0;
        if (isInFieldRageByX)
        {
            cellsList.Add(cells[new Vector2Int(cellObject.cellId.x,cellObject.cellId.y)].transform.gameObject);
            cellsList.Add(cells[new Vector2Int(cellObject.cellId.x-1,cellObject.cellId.y)].transform.gameObject);
            cellsList.Add(cells[new Vector2Int(cellObject.cellId.x+1,cellObject.cellId.y)].transform.gameObject);
        }
        else
        {
            return;
        }
    }
    
    private void OutlineAllCells(List<GameObject> cellsList, bool cellStatus)
    {
        foreach (var cell in cellsList)
        {
            cell.GetComponent<CellOutliner>().StartOutline(cellStatus);
        }
    }

    private bool CheckForEmptyness(List<GameObject> cells)
    {
        foreach (var cell in cells)
        {
            var cellEmptyness = cell.GetComponent<Cell>().isEmpty;
            if(cellEmptyness) return true;
        }

        return false;
    }
}