using UnityEngine;

public class Boostrapper : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] public GameObject tilePrefab;
    [SerializeField] public Transform gridHolder;

    private void Awake()
    {
        IGridService gridService = new GridService(tilePrefab, gridHolder);

        ServiceLocator.Register<IGridService>(gridService);
    }
}
