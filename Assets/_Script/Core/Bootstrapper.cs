using UnityEngine;
using System.Collections.Generic;

public class BootStrapper : MonoBehaviour
{
    [Header("Grid Configuration")]
    [SerializeField] public GameObject TilePrefab;
    [SerializeField] public Transform GridHolder;

    [Header("Camera Configurations")]
    [SerializeField] public List<Camera> AvailableCameras;

    [Header("Tiles Materials")]
    [SerializeField] private Material _matP1;
    [SerializeField] private Material _matP2;
    [SerializeField] private Material _matFog;

    private void Awake()
    {
        // Grid
        IGridService gridService = new GridService(TilePrefab, GridHolder);
        ServiceLocator.Register<IGridService>(gridService);

        // Camera
        ICameraService cameraService = new CameraService(AvailableCameras);
        ServiceLocator.Register<ICameraService>(cameraService);
        cameraService.InitializeCameras();

        // Economy
        IEconomyService economyService = new EconomyService();
        ServiceLocator.Register<IEconomyService>(economyService);

        //Turn
        ITurnService turnService = new TurnService();
        ServiceLocator.Register<ITurnService>(turnService);

        // Fog
        var fog = new FogOfWarService(_matP1, _matP2, _matFog);
        ServiceLocator.Register<IFogOfWarService>(fog);
        fog.Init();
    }

    private void Start()
    {
        ServiceLocator.Get<IFogOfWarService>().UpdateFog();
    }
}
