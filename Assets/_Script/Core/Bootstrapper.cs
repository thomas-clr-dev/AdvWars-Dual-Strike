using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [Header("Grid Configuration")]
    public GameObject tilePrefab;
    public Transform gridHolder;

    [Header("Cameras Configuration")]
    public List<Camera> availableCameras;

    private void Awake()
    {
        Utils.ColorLog("System launching...", "Cyan");

        IGridService gridService = new GridService(tilePrefab, gridHolder);
        ServiceLocator.Register<IGridService>(gridService);

        ICameraService cameraService = new CameraService(availableCameras);
        ServiceLocator.Register<ICameraService>(cameraService);

        cameraService.InitializeCameras();
    }
}
