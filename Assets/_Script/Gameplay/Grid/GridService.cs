using System;
using UnityEngine;

public class GridService : IGridService
{
    private TileManager[,] _tiles;

    [Header("Grid Settings")]
    [Min(0)] private int _width = 10;
    [Min(0)] private int _height = 10;
    [Min(1f)] private float cellSize = 1.1f;

    public GridService(GameObject tilePrefab, Transform parentContainer)
    {
        GenerateGrid(tilePrefab, parentContainer);
    }

    private void GenerateGrid(GameObject tilePrefab, Transform parentContainer)
    {
        _tiles = new TileManager[_width, _height];

        for (int x  = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Vector3 position = new Vector3 (x * cellSize, 0, y * cellSize);
                GameObject newTileObj = UnityEngine.Object.Instantiate(tilePrefab, position, Quaternion.identity, parentContainer);

                newTileObj.name = $"Tile_{x}_{y}";

                TileManager tileScript = newTileObj.GetComponent<TileManager>();
                tileScript.tileCoordinates = new Vector2Int(x, y);

                _tiles[x, y] = tileScript;
            }
        }
        Utils.ColorLog("Grid generation success !", "Green");
    }

    public TileManager GetTile(int x, int y)
    {
        if (x >= 0 &&  y >= 0 && x <  _width && y < _height)
        {
            return _tiles[x, y];
        }
        return null;
    }
}
