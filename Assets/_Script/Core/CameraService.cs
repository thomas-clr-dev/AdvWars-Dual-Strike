using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class CameraService : ICameraService
{
    private List<Camera> _allCameras;

    public CameraService(List<Camera> cameras)
    {
        _allCameras = cameras;
    }

    public void InitializeCameras()
    {
        foreach (var cam in _allCameras)
        {
            Utils.SafeSetActive(cam.gameObject, false);
            cam.rect = new Rect(0, 0, 1, 1);
        }

        var shuffleCams = _allCameras.OrderBy(x => Random.value).ToList();

        Camera p1Cam = shuffleCams[0];
        Camera p2Cam = shuffleCams[1];

        p1Cam.rect = new Rect(0, 0, 0.5f, 1f);
        Utils.SafeSetActive(p1Cam.gameObject, true);
        p1Cam.name += " (J1 - Left)";

        p2Cam.rect = new Rect(0.5f, 0, 0.5f, 1f);
        Utils.SafeSetActive (p2Cam.gameObject, true);
        p2Cam.name += " (J2 - Right)";

        Utils.ColorLog($"Camera J1 assigned : J1 = {p1Cam.name}", "Cyan");
        Utils.ColorLog($"Camera J2 assigned : J2 = {p2Cam.name}", "Orange");
    }
}
