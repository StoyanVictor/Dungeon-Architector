using System.Collections.Generic;
using UnityEngine;

public class GameFieldGenerator : MonoBehaviour
{
   [SerializeField] private int width, height;
   [SerializeField] private GameObject tilePrefab;
   private Dictionary<Vector2Int, Cell> cells = new Dictionary<Vector2Int, Cell>();

   public int GetFieldWidth() => width;
   public Dictionary<Vector2Int, Cell> GetCells() => cells;

   void GenerateGameField()
   {
      for (int x = 0; x < width; x++)
      {
         for (int y = 0; y < height; y++)
         {
            var tile = Instantiate(tilePrefab);
            tile.transform.position = new Vector3(x, 0, y);
            cells[new Vector2Int(x, y)] = tile.GetComponent<Cell>();
            cells[new Vector2Int(x, y)].cellId = new Vector2Int(x, y);
         }
      }
   }

   private void Awake()
   {
      GenerateGameField();
      foreach (var c in cells)
      {
         print(c.Key);
      }
   }

}