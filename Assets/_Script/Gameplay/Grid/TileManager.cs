using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Vector2Int tileCoordinates;

    public void SetColor(Material mat)
    {
        GetComponent<Renderer>().material = mat;
    }
}
