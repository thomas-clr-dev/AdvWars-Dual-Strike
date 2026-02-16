using UnityEngine;

public interface IGridService
{
    TileManager GetTile(int x, int y);
}
