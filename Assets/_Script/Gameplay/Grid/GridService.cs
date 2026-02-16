using System;
using UnityEngine;

public class GridService : IGridService
{
    private TileManager[,] _tiles;
    [Header("Grid Settings")]
    [SerializeField] private int _width = 9;
    [SerializeField] private int _height = 9;
    [SerializeField] private float _cellSize = 1.1f;

    public GridService(GameObject tilePrefab, Transform parentContainer)
    {
        GenerateGrid(tilePrefab, parentContainer);
    }

    private void GenerateGrid(GameObject tilePrefab, Transform parent)
    {
        _tiles = new TileManager[_width, _height];

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Vector3 position = new Vector3(x * _cellSize, 0, y * _cellSize);

                GameObject newTileObj = UnityEngine.Object.Instantiate(tilePrefab, position, Quaternion.identity, parent);

                TileManager tileScript = newTileObj.GetComponent<TileManager>();
                tileScript.tileCoordinates = new Vector2Int(x, y);

                _tiles[x, y] = tileScript;
            }
        }
        Utils.ColorLog("Success of grid generation !", "Green");
    }

    public TileManager GetTile(int x, int y)
    {
        if (x >= 0 && y >= 0 && x <= _width && y <= _height)
        {
            return _tiles[x, y];
        }
        return null;
    }
}
