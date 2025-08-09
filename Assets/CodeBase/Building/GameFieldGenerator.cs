using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class GameFieldGenerator : MonoBehaviour
{
   [SerializeField] private int width, height;
   [SerializeField] private GameObject tilePrefab;
   [SerializeField] private NavMeshSurface surface;
   private Dictionary<Vector2Int, Cell> cells = new Dictionary<Vector2Int, Cell>();
   private CellSpawner cellSpawner;

   [Inject]
   public void Costruct(CellSpawner _cellSpawner)
   {
      cellSpawner = _cellSpawner;
   }

   public int GetFieldWidth() => width;
   public Dictionary<Vector2Int, Cell> GetCells() => cells;

   void GenerateGameField()
   {
      for (int x = 0; x < width; x++)
      {
         for (int y = 0; y < height; y++)
         {
            var cell = cellSpawner.Create();
            cell.transform.position = new Vector3(x, 0, y);
            cells[new Vector2Int(x, y)] = cell.GetComponent<Cell>();
            cells[new Vector2Int(x, y)].cellId = new Vector2Int(x, y);
         }
      }
   }

   private void Start()
   {
      GenerateGameField();
      surface.BuildNavMesh();
   }

}