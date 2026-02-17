using UnityEngine;


public interface IFogOfWarService { void UpdateFog(); }

public class FogOfWarService : IFogOfWarService
{
    private IGridService _gridService;
    private ITurnService _turnService;
    private Material _p1Mat, _p2Mat, _fogMat;

    public FogOfWarService(Material p1,  Material p2, Material fog)
    {
        _p1Mat = p1; _p2Mat = p2; _fogMat = fog;
    }

    public void Init()
    {
        _gridService = ServiceLocator.Get<IGridService>();
        _turnService = ServiceLocator.Get<ITurnService>();
        _turnService.OnTurnChanged += UpdateFog;
    }

    public void UpdateFog()
    {
        int activePlayer = _turnService.CurrentPlayerID;

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                var tile = _gridService.GetTile(x, y);
                if (tile != null)
                {
                    tile.UpdateVisuals(activePlayer, _p1Mat, _p2Mat, _fogMat);
                    Utils.ColorLog($"Tile {tile.tileCoordinates} updated");
                }
            }
        }
    }
}
