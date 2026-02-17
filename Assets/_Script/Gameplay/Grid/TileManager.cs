using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Vector2Int tileCoordinates;
    public int ownerID = 0; // 0 = Neutral, 1 = P1, 2 = P2
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void UpdateVisuals(int currentPlayerID, Material p1,  Material p2, Material fog)
    {
        if (ownerID == currentPlayerID)
        {
            if (ownerID == 1) _renderer.material = p1;
            else if (ownerID == 2) _renderer.material = p2;
        }
        else
        {
            _renderer.material = fog;
        }
    }

    //public void SetColor(Material mat)
    //{
    //    GetComponent<Renderer>().material = mat;
    //}
}
