using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedInSensibility = 0.5f;
    [SerializeField] float zoomedOutSensibility = 2f;

    bool zoomToggle = false;

    private void Update()
    {
        HandleZoom();
    }

    private void HandleZoom()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (!zoomToggle)
            {
                zoomToggle = true;
                fpsCamera.fieldOfView = zoomedInFOV;
            }
            else
            {
                zoomToggle = false;
                fpsCamera.fieldOfView = zoomedOutFOV;
            }
            adjustMouseSensibility();
        }
    }

    private void adjustMouseSensibility()
    {
        if (zoomToggle)
        {
            fpsController.mouseLook.XSensitivity = zoomedInSensibility;
            fpsController.mouseLook.YSensitivity = zoomedInSensibility;
        }
        else
        {
            fpsController.mouseLook.XSensitivity = zoomedOutSensibility;
            fpsController.mouseLook.YSensitivity = zoomedOutSensibility;
        }
    }
}
